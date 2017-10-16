using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Geco.Common;
using Geco.Common.MetadataProviders.SqlServer;
using Geco.Common.SimpleMetadata;
using Geco.Config;
using Geco.Database;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using static System.ConsoleColor;
using static Geco.Common.ColorConsole;

namespace Geco
{
    /// <summary>
    /// As simple as it gets code generator, which is a console application that runs code generation tasks written in C#.
    /// </summary>
    /// <remarks>
    /// Task discovery is done at runtime by scanning current assembly for all the types that implement <see cref="IRunnable"/> interfaces.
    /// The tasks are resolved using a <see cref="ServiceProvider"/>. Generator tasks can declare a options class using the <see cref="OptionsAttribute"/>
    /// in order to have the options be read from the <c>appsettings.json</c> configuration file and registered in the <see cref="ServiceCollection"/>
    /// </remarks>
    public class Program
    {
        private static Dictionary<string, Type> runnableTypes;

        static int Main(string[] args)
        {
            try
            {
                var app = new CommandLineApplication();
                app.Name = "Geco";
                app.HelpOption("-?|-h|--help");

                ServiceProvider serviceProvider = null;
                IOptions<RootConfig> rootConfig = null;
                IConfigurationRoot configurationRoot = null;

                app.Command("run", command =>
                {
                    command.HelpOption("-?|-h|--help");
                    var taskList = command.Option("-tl|--tasklist "
                        , "The name of the task list from appsettings.json to execute. The task list is an array of task names."
                        , CommandOptionType.SingleValue);
                    var taskNames = command.Option("-tn|--tasknames <tasknames>"
                        , "The name(s) of the tasks to execute. The task list is an array of task names."
                        , CommandOptionType.MultipleValue);
                    command.OnExecute(() =>
                    {
                        serviceProvider = ConfigureServices(app.RemainingArguments.ToArray(), out rootConfig, out configurationRoot);
                        if (taskList.HasValue())
                            RunTaskListFromConfig(rootConfig.Value, serviceProvider, taskList.Value(), configurationRoot);
                        if (taskNames.HasValue())
                            RunTasksList(rootConfig.Value, serviceProvider, taskNames.Values, configurationRoot);
                        return 0;
                    });
                });
                app.OnExecute(() =>
                {
                    WriteLogo();
                    serviceProvider = ConfigureServices(args, out rootConfig, out configurationRoot);
                    WriteLine("<< Geco is running in interactive mode! >>", Yellow);
                    InteractiveLoop(rootConfig.Value, serviceProvider);
                    WriteLine("C ya!", Yellow);
                    return 0;
                });

                return app.Execute(args);
            }
            catch (Exception ex)
            {
                WriteLine("==============================================", Red);
                WriteLine("=== Geco stopped due to error:", Red);
                WriteLine(ex.ToString(), Yellow);
                WriteLine("==============================================", Red);
                return -1;
            }
        }

        private static void InteractiveLoop(RootConfig rootConfig, ServiceProvider serviceProvider)
        {
            Func<bool> displayAndRun;
            do
            {
                displayAndRun = BuildMenu(rootConfig, serviceProvider);
            } while (displayAndRun());
        }

        private static Func<bool> BuildMenu(RootConfig rootConfig, ServiceProvider serviceProvider)
        {
            Console.WriteLine();
            WriteLine("Select option:", White);
            var actions = new Dictionary<string, Action>();
            foreach (var taskInfo in rootConfig.Tasks.WithInfo())
            {
                var taskNr = (taskInfo.Index + 1).ToString();
                WriteLine(($"{taskNr}. ", White), ($"{taskInfo.Item.Name}", Blue));
                actions.Add(taskNr, () => RunTask(serviceProvider, taskInfo.Item));
            }
            WriteLine(($"q. ", White), ($"Quit", ConsoleColor.Yellow));
            Write(">>", White);

            bool Choose()
            {
                var command = Console.ReadLine();
                if (string.Equals(command, "q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine();
                    return false;
                }
                if (actions.TryGetValue(command, out var action))
                    action();
                return true;
            }
            return Choose;
        }

        private static ServiceProvider ConfigureServices(string[] args, out IOptions<RootConfig> cfg, out IConfigurationRoot configurationRoot)
        {
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .Build();

            configurationRoot = configRoot;

            //setup the DI
            var serviceCollection = new ServiceCollection()
                .AddLogging()
                .AddSingleton(configRoot)
                .AddOptions()
                .AddSingleton<IMetadataProvider, SqlServerMetadataProvider>()
                .AddSingleton<IInflector, EnglishInflector>()
                .Configure<RootConfig>(rooConfig => configRoot.Bind(rooConfig));

            ScanTasks(serviceCollection, configRoot);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            cfg = serviceProvider.GetRequiredService<IOptions<RootConfig>>();
            return serviceProvider;
        }

        private static void WriteLogo()
        {
            WriteLine("********************************************************", Blue);
            WriteLine($"* ** Geco v{Assembly.GetEntryAssembly().GetName().Version} **                                  *", Blue);
            WriteLine("*                                                      *", Blue);
            WriteLine(("*", Blue), (@"        .)/     )/,         ", Green), ("        Copyright (c)     *", Blue));
            WriteLine(("*", Blue), (@"         /`-._,-'`._,@`-,   ", Green), ("         iQuarc 2017      *", Blue));
            WriteLine(("*", Blue), (@"  ,  _,-=\,-.__,-.-.__@/    ", Green), ("    - Generator Console - *", Blue));
            WriteLine(("*", Blue), (@" (_,'    )\`    '(`         ", Green), ("           - Geco -       *", Blue));
            WriteLine("*                                                      *", Blue);
            WriteLine("********************************************************", Blue);
        }

        private static void ScanTasks(IServiceCollection serviceCollection, IConfigurationRoot configuration)
        {
            var rootConfig = new RootConfig();
            configuration.Bind(rootConfig);

            runnableTypes = Assembly.GetAssembly(typeof(Program))
                .GetTypes()
                .Where(t => typeof(IRunnable).IsAssignableFrom(t))
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.GetConstructors().Any())
                .ToDictionary(t => t.Name);

            foreach (var runnableType in runnableTypes.Values)
            {
                serviceCollection.Add(new ServiceDescriptor(runnableType, runnableType, ServiceLifetime.Transient));
            }

            //RootConfig rootConfig
            foreach (var taskConfig in rootConfig.Tasks.WithInfo())
            {
                if (!runnableTypes.ContainsKey(taskConfig.Item.Generator))
                {
                    WriteLine($"Task configuration for:[{taskConfig.Item.Generator}] has no corresponding service to be applied to", DarkYellow);
                    continue;
                }
                var taskType = runnableTypes[taskConfig.Item.Generator];
                var optionsAttribute = (OptionsAttribute)taskType.GetCustomAttribute(typeof(OptionsAttribute));
                if (optionsAttribute != null)
                {
                    var options = Activator.CreateInstance(optionsAttribute.OptionType);
                    configuration.GetSection($"Tasks:{taskConfig.Index}:Options").Bind(options);
                    serviceCollection.AddSingleton(optionsAttribute.OptionType, options);
                }
            }
        }

        private static void RunTaskListFromConfig(RootConfig cfg, ServiceProvider serviceProvider, string taskListName, IConfigurationRoot configurationRoot)
        {
            var taskList = new List<string>();
            configurationRoot.Bind(taskListName, taskList);
            RunTasksList(cfg, serviceProvider, taskList, configurationRoot);
        }

        private static void RunTasksList(RootConfig cfg, ServiceProvider serviceProvider, IEnumerable<string> taskList, IConfigurationRoot configurationRoot)
        {
            foreach (var taskName in taskList)
            {
                var task = cfg.Tasks.Find(t => t.Name == taskName);
                task.OutputToConsole = false;
                RunTask(serviceProvider, task);
            }
        }

        private static void RunTask(ServiceProvider serviceProvider, TaskConfig itemInfo)
        {
            WriteLine("--------------------------------------------------------", Yellow);
            WriteLine(("*** Starting ", Yellow), ($" {itemInfo.Name} ", Blue));
            var sw = new Stopwatch();
            sw.Start();
            var task = (IRunnable)serviceProvider.GetService(runnableTypes[itemInfo.Generator]);
            if (task is IOutputRunnable to)
            {
                to.OutputToConsole = itemInfo.OutputToConsole;
                to.BaseOutputPath = itemInfo.BaseOutputPath;
                to.CleanFilesPattern = itemInfo.CleanFilesPattern;
            }

            if (task is IRunableConfirmation co)
            {
                Console.Write(co.ConfirmationQuestion);
                Console.Write(":");
                co.Answer(Console.ReadLine());
                Console.WriteLine();
            }
            task.Run();
            sw.Stop();
            Console.WriteLine();
            WriteLine(("Task", Yellow), ($" {itemInfo.Name} ", Blue), ("completed in", Yellow),
                ($" {sw.ElapsedMilliseconds} ms", Green));
        }
    }
}