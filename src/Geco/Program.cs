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
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using static Geco.Common.ColorConsole;
using static System.ConsoleColor;

namespace Geco
{
    /// <summary>
    /// As simple as it gets code generator, which is a console application that runs code generation tasks written in C#.
    /// </summary>
    /// <remarks>
    /// Task discovery is done at runtime by scanning current assembly for all the types that implement <see cref="IRunnable"/> interfaces.
    /// The tasks are resolved using a <see cref="ServiceProvider"/>. Generator tasks can declare a options class using the <see cref="OptionsAttribute"/>
    /// in order to have the options be read from the <c>appsettings.json</c> configuration file and registered in the <see cref="Microsoft.Extensions.DependencyInjection.ServiceCollection"/>
    /// </remarks>
    public class Program
    {
        private Dictionary<string, Type> runnableTypes;
        private IServiceCollection ServiceCollection;
        private RootConfig RootConfig;
        private IConfigurationRoot ConfigurationRoot;
        private bool Interactive { get; set; }
        static int Main(string[] args)
        {
            var p = new Program();
            return p.Run(args); 
        }

        private int Run(string[] args)
        {
            try
            {
                var app = new CommandLineApplication();
                app.Name = "Geco";
                app.HelpOption("-?|-h|--help");

                app.Command("run", command =>
                {
                    command.HelpOption("-?|-h|--help");
                    var taskList = command.Option("-tl|--tasklist "
                        , "The name of the task list from appsettings.json to execute. The task list is an array of task names.", CommandOptionType.SingleValue);
                    var taskNames = command.Option("-tn|--taskname <taskname>"
                        , "The name(s) of the tasks to execute. The task names is an list of task names parameters -tn <xx> -tn <yy>.", CommandOptionType.MultipleValue);
                    command.OnExecute(() =>
                    {
                        ConfigureServices(app.RemainingArguments.ToArray());
                        if (taskList.HasValue())
                            RunTaskListFromConfig(taskList.Value());
                        if (taskNames.HasValue())
                            RunTasksList(taskNames.Values);
                        return 0;
                    });
                });
                app.OnExecute(() =>
                {
                    WriteLogo();
                    ConfigureServices(app.RemainingArguments.ToArray());
                    WriteLine($"<< Geco is running in interactive mode! >>", Yellow);
                    InteractiveLoop();
                    WriteLine($"C ya!", Yellow);
                    return 0;
                });

                return app.Execute(args);
            }
            catch (Exception ex)
            {
                WriteLine($"==============================================", Red);
                WriteLine($"=== Geco stopped due to error:", Red);
                WriteLine($"{ex}", Yellow);
                WriteLine($"==============================================", Red);
                return -1;
            }
        }

        private void InteractiveLoop()
        {
            Interactive = true;
            Func<bool> displayAndRun;
            do
            {
                displayAndRun = BuildMenu();
            } while (displayAndRun());
        }

        private Func<bool> BuildMenu()
        {
            Console.WriteLine();
            WriteLine($"Select option {("(then press Enter)", Gray)}:", White);
            var actions = new Dictionary<string, Action>();
            foreach (var taskInfo in RootConfig.Tasks.WithInfo())
            {
                var taskNr = (taskInfo.Index + 1).ToString();
                WriteLine(($"{taskNr}. ", White), ($"{taskInfo.Item.Name}", Blue));
                actions.Add(taskNr, () => RunTask(taskInfo.Item));
            }
            WriteLine(("q. ", White), ("Quit", ConsoleColor.Yellow));
            Write($">>", White);

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

        private void ConfigureServices(string[] args)
        {
            ConfigurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .Build();

            //setup the DI
            ServiceCollection = new ServiceCollection()
                .AddLogging()
                .AddSingleton(ConfigurationRoot)
                .AddOptions()
                .AddSingleton<IMetadataProvider, SqlServerMetadataProvider>()
                .AddSingleton<IInflector, EnglishInflector>();

            ScanTasks();
        }

        private static void WriteLogo()
        {
            var version = Assembly.GetEntryAssembly().GetName().Version;
            WriteLine($"********************************************************", Blue);
            WriteLine($"* ** Geco v{version} **                                  *", Blue);
            WriteLine($"*                                                      *", Blue);
            WriteLine(("*", Blue), (@"        .)/     )/,         ", Green), ("        Copyright (c)     *", Blue));
            WriteLine(("*", Blue), (@"         /`-._,-'`._,@`-,   ", Green), ("         iQuarc 2017      *", Blue));
            WriteLine(("*", Blue), (@"  ,  _,-=\,-.__,-.-.__@/    ", Green), ("    - Generator Console - *", Blue));
            WriteLine(("*", Blue), (@" (_,'    )\`    '(`         ", Green), ("           - Geco -       *", Blue));
            WriteLine($"*                                                      *", Blue);
            WriteLine($"********************************************************", Blue);
        }

        private void ScanTasks()
        {
            RootConfig = new RootConfig();
            ConfigurationRoot.Bind(RootConfig);

            runnableTypes = Assembly.GetAssembly(typeof(Program))
                .GetTypes()
                .Where(t => typeof(IRunnable).IsAssignableFrom(t))
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.GetConstructors().Any())
                .ToDictionary(t => t.FullName);

            foreach (var runnableType in runnableTypes.Values)
            {
                ServiceCollection.Add(new ServiceDescriptor(runnableType, runnableType, ServiceLifetime.Transient));
            }

            //RootConfig rootConfig
            foreach (var taskConfig in RootConfig.Tasks.WithInfo())
            {
                if (!runnableTypes.ContainsKey(taskConfig.Item.TaskClass))
                {
                    WriteLine($"Task configuration for:[{taskConfig.Item.TaskClass}] has no corresponding service to be applied to", DarkYellow);
                    continue;
                }
                var taskType = runnableTypes[taskConfig.Item.TaskClass];
                var optionsAttribute = (OptionsAttribute)taskType.GetCustomAttribute(typeof(OptionsAttribute));
                if (optionsAttribute != null)
                {
                    taskConfig.Item.ConfigIndex = taskConfig.Index + 1;
                    var options = Activator.CreateInstance(optionsAttribute.OptionType);
                    ConfigurationRoot.GetSection($"Tasks:{taskConfig.Item.ConfigIndex}:Options").Bind(options);
                    ServiceCollection.Replace(new ServiceDescriptor(optionsAttribute.OptionType, options));
                }
            }
        }

        private void RunTaskListFromConfig(string taskListName)
        {
            var taskList = new List<string>();
            ConfigurationRoot.Bind(taskListName, taskList);
            RunTasksList(taskList);
        }

        private void RunTasksList(IEnumerable<string> taskList)
        {
            foreach (var taskName in taskList)
            {
                var task = RootConfig.Tasks.Find(t => t.Name == taskName);
                task.OutputToConsole = false;
                RunTask(task);
            }
        }

        private void RunTask(TaskConfig itemInfo)
        {
            var sw = new Stopwatch();
            try
            {
                WriteLine($"--------------------------------------------------------", Yellow);
                WriteLine(("*** Starting ", Yellow), ($" {itemInfo.Name} ", Blue));

                var taskType = runnableTypes[itemInfo.TaskClass];
                var optionsAttribute = (OptionsAttribute)taskType.GetCustomAttribute(typeof(OptionsAttribute));
                if (optionsAttribute != null)
                {
                    var options = Activator.CreateInstance(optionsAttribute.OptionType);
                    ConfigurationRoot.GetSection($"Tasks:{itemInfo.ConfigIndex}:Options").Bind(options);
                    ServiceCollection.Replace(new ServiceDescriptor(optionsAttribute.OptionType, options));
                }

                using (var provider = ServiceCollection.BuildServiceProvider())
                {
                    sw.Start();
                    var task = (IRunnable)provider.GetService(taskType);
                    if (task is IOutputRunnable to)
                    {
                        to.OutputToConsole = itemInfo.OutputToConsole;
                        to.BaseOutputPath = itemInfo.BaseOutputPath;
                        to.CleanFilesPattern = itemInfo.CleanFilesPattern;
                        to.Interactive = Interactive;
                    }

                    if (task is IRunableConfirmation co && Interactive)
                    {
                        sw.Stop();
                        if (!co.GetUserConfirmation())
                        {
                            WriteLine(("*** Task was canceled ", Yellow), ($" {itemInfo.Name} ", Blue));
                            return;
                        }
                        sw.Start();
                    }
                    try
                    {
                        task.Run();
                    }
                    catch (OperationCanceledException)
                    {
                        WriteLine(("*** Task was aborted ", Yellow), ($" {itemInfo.Name} ", Blue));
                    }
                }
            }
            catch (Exception ex) when (Interactive)
            {
                WriteLine($"Error running {(itemInfo.Name, Blue)}: Error:{(ex.Message, Red)}", DarkRed);
                WriteLine($"Detail: {ex}", DarkYellow);
            }
            sw.Stop();
            Console.WriteLine();
            WriteLine(("Task", Yellow), ($" {itemInfo.Name} ", Blue), ("completed in", Yellow), ($" {sw.ElapsedMilliseconds} ms", Green));
        }
    }
}