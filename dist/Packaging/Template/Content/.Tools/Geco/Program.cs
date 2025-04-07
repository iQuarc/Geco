// Copyright © iQuarc 2017 - Pop Catalin Sever
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Threading;
using Geco.Config;
using Humanizer;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Geco;

/// <summary>
///    As simple as it gets code generator, which is a console application that runs code generation tasks written in C#.
/// </summary>
/// <remarks>
///    Task discovery is done at runtime by scanning current assembly for all the types that implement
///    <see cref="IRunnable" /> interfaces.
///    The tasks are resolved using a <see cref="ServiceProvider" />. Generator tasks can declare a options class using
///    the <see cref="OptionsAttribute" />
///    in order to have the options be read from the <c>appsettings.json</c> configuration file and registered in the
///    <see cref="Microsoft.Extensions.DependencyInjection.ServiceCollection" />
/// </remarks>
public class Program : ITaskRunner
{
   private const    int                       taskMaxNestingLevel = 50;
   private readonly RootConfig                rootConfig          = new();
   private          IConfigurationRoot?       configurationRoot;
   private          int                       nestingLevel;
   private          string                    path = "/";
   private          Dictionary<string, Type>? runnableTypes;
   private          IServiceCollection?       serviceCollection;
   public           bool                      Interactive { get; private set; }

   public bool Choose(IReadOnlyList<(FormattableString Choice, Action Action)> choices)
   {
      var actions = new Dictionary<string, Action>();
      while (true)
      {
         WriteLine($"Path: {(path, Yellow)}", DarkCyan);
         WriteLine($"Select option {("(then press Enter)", Gray)}:", White);
         foreach (var choice in choices.WithInfo())
         {
            Write(($"{choice.Index + 1}. ", White));
            WriteLine(choice.Item.Choice, White);
            actions[(choice.Index + 1).ToString()] = choice.Item.Action;
         }

         WriteLine(("q. ", White), ("Back", Yellow));
         Write($">>", White);
         var command = Console.ReadLine()?.Trim() ?? "";
         if (string.Equals(command, "q", StringComparison.OrdinalIgnoreCase))
         {
            Console.WriteLine();
            return false;
         }

         if (actions.TryGetValue(command, out var action))
         {
            action();
            return true;
         }

         WriteLine($"Bad command or file name", Yellow);
         WriteLine();
      }
   }

   void ITaskRunner.RunTask(string taskName, object config)
   {
      CheckInitialized();

      var task = FindTask(rootConfig.Tasks, taskName);
      if (task == null)
      {
         WriteLine(("*** Error: Task ", Red), ($" {taskName} ", Blue), ("not found!", Red));
         return;
      }

      RunTask(task, config);
   }

   void ITaskRunner.RunTasks(IEnumerable<string> taskNames)
   {
      RunTasksList(taskNames);
   }

   void ITaskRunner.RunNamedTaskList(string taskListName)
   {
      RunTaskListFromConfig(taskListName);
   }


   private static int Main(string[] args)
   {
      var p = new Program();
      return p.Run(args);
   }

   private int Run(string[] args)
   {
      try
      {
         Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

         var app = new CommandLineApplication(false);
         app.Name = "Geco";
         app.HelpOption("-?|-h|--help");

         app.Command("run", command =>
         {
            command.HelpOption("-?|-h|--help");
            var taskList = command.Option("-tl|--tasklist"
               , "The name of the task list from appsettings.json to execute. The task list is an array of task names.",
               CommandOptionType.SingleValue);
            var taskNames = command.Option("-tn|--taskname <taskname>"
               , "The name(s) of the tasks to execute. The task names is an list of task names parameters -tn <xx> -tn <yy>.",
               CommandOptionType.MultipleValue);
            command.OnExecute(() =>
            {
               Configure(app.RemainingArguments.ToArray());
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
            Configure(app.RemainingArguments.ToArray());
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

   private static void WriteLogo()
   {
      var version = Assembly.GetEntryAssembly()!.GetName().Version;
      WriteLine($"********************************************************", Blue);
      WriteLine($"* ** Geco v{version} **                                  *", Blue);
      WriteLine($"*                                                      *", Blue);
      WriteLine(("*", Blue), (@"        .)/     )/,         ", Green), ("        Copyright (c)     *", Blue));
      WriteLine(("*", Blue), (@"         /`-._,-'`._,@`-,   ", Green), ("         iQuarc 2017      *", Blue));
      WriteLine(("*", Blue), (@"  ,  _,-=\,-.__,-.-.__@/    ", Green), ("    - Generator Console - *", Blue));
      WriteLine(("*", Blue), (@" (_,'    )\`    '(`         ", Green), ("           - Geco -       *", Blue));
      WriteLine($"*                                                      *", Blue);
      WriteLine($"*          {("https://github.com/iQuarc/Geco.Core", DarkMagenta)}         *", Blue);
      WriteLine($"********************************************************", Blue);
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
      if (rootConfig == null)
         throw new InvalidOperationException("RootConfig is not initialized");

      Dictionary<string, Action> BuildMenuRecursive(IReadOnlyCollection<TaskConfig> tasks, string path)
      {
         this.path = path;
         Console.WriteLine();
         WriteLine($"Path: {(path, Yellow)}", DarkCyan);
         WriteLine($"Select option {("(then press Enter)", Gray)}:", White);
         var actions = new Dictionary<string, Action>();

         foreach (var taskInfo in tasks.WithInfo())
         {
            var taskNr        = (taskInfo.Index + 1).ToString();
            var hasChildTasks = taskInfo.Item.TaskClass == null && taskInfo.Item.Tasks.Count > 0;
            WriteLine(($"{taskNr}. ", White), ($"{taskInfo.Item.Name}", taskInfo.Item.Color),
               (hasChildTasks ? " > " : "", Yellow));

            actions.Add(taskNr, () =>
            {
               if (taskInfo.Item.TaskClass != null)
               {
                  RunTask(taskInfo.Item);
               }
               else if (taskInfo.Item.Tasks.Count > 0)
               {
                  Dictionary<string, Action> subActions;
                  do
                  {
                     subActions = BuildMenuRecursive(taskInfo.Item.Tasks, path + $"{taskInfo.Item.Name}/");
                     WriteLine(("q. ", White), ("Back", Yellow));
                     Write($">>", White);
                  } while (Choose(subActions));
               }
            });
         }

         return actions;
      }

      var act = BuildMenuRecursive(rootConfig.Tasks, "/");
      WriteLine(("q. ", White), ("Quit", Yellow));
      Write($">>", White);

      bool Choose(Dictionary<string, Action> actions)
      {
         var command = Console.ReadLine()?.Trim() ?? "";
         if (string.Equals(command, "q", StringComparison.OrdinalIgnoreCase))
         {
            Console.WriteLine();
            return false;
         }

         if (actions.TryGetValue(command, out var action))
            action();
         else
            WriteLine($"Bad command or file name", Yellow);
         return true;
      }

      return () => Choose(act);
   }

   private void Configure(string[] args)
   {
      ConfigureServices(args);
      ScanTasks();
      ScanServices();
   }

   [MemberNotNull(nameof(configurationRoot), nameof(serviceCollection))]
   private void ConfigureServices(string[] args)
   {
      configurationRoot = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json")
         .AddJsonFile("appsetings.json.user", true)
         .AddUserSecrets(typeof(Program).Assembly)
         .AddCommandLine(args)
         .Build();

      configurationRoot.Bind(rootConfig);

      //set up the DI
      serviceCollection = new ServiceCollection()
         .AddLogging()
         .AddSingleton(configurationRoot)
         .AddSingleton<ITaskRunner>(this)
         .AddOptions();
   }

   [MemberNotNull(nameof(configurationRoot), nameof(serviceCollection), nameof(runnableTypes))]
   private void CheckInitialized()
   {
      if (configurationRoot == null)
         throw new InvalidOperationException("ConfigurationRoot is not initialized");

      if (serviceCollection == null)
         throw new InvalidOperationException("ServiceCollection is not initialized");

      if (runnableTypes == null)
         throw new InvalidOperationException("RunnableTypes is not initialized");
   }

   private void ScanTasks()
   {
      if (serviceCollection == null)
         throw new InvalidOperationException("ServiceCollection is not initialized");

      runnableTypes = Assembly.GetAssembly(typeof(Program))!
         .GetTypes()
         .Where(t => typeof(IRunnable).IsAssignableFrom(t))
         .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.GetConstructors().Any())
         .ToDictionary(t => t.FullName!);

      foreach (var runnableType in runnableTypes.Values)
         serviceCollection.Add(new ServiceDescriptor(runnableType, runnableType, ServiceLifetime.Transient));

      ScanTasksRecursive(rootConfig.Tasks);

      void ScanTasksRecursive(
         IReadOnlyCollection<TaskConfig> tasks,
         string                          parentPath = "",
         TaskConfig?                     parent     = null)
      {
         //RootConfig
         foreach (var taskConfig in tasks.WithInfo())
         {
            if (taskConfig.Item.TaskClass != null && !runnableTypes.ContainsKey(taskConfig.Item.TaskClass))
            {
               WriteLine(
                  $"Task configuration for:[{taskConfig.Item.TaskClass}] has no corresponding service to be applied to",
                  DarkYellow);
               continue;
            }

            var currentPath = $"{parentPath}Tasks:{taskConfig.Index}:";

            if (taskConfig.Item.TaskClass != null)
            {
               var taskType = runnableTypes[taskConfig.Item.TaskClass];
               taskConfig.Item.ConfigPath = $"{currentPath}Options";

               var colorAttribute =
                  (ConsoleColorAttribute?)taskType.GetCustomAttribute(typeof(ConsoleColorAttribute));
               if (colorAttribute != null)
                  taskConfig.Item.Color = colorAttribute.ConsoleColor;
            }

            ScanTasksRecursive(taskConfig.Item.Tasks, currentPath, taskConfig.Item);
         }
      }
   }

   private void ScanServices()
   {
      CheckInitialized();

      var serviceTypes = Assembly.GetAssembly(typeof(Program))!
         .GetTypes()
         .Select(t => new { Type = t, Attribute = t.GetCustomAttribute<ServiceAttribute>() })
         .Where(x => x.Attribute?.ContractType != null && !x.Type.IsAbstract && !x.Type.IsGenericTypeDefinition &&
                     x.Type.GetConstructors().Any());
      foreach (var serviceType in serviceTypes)
         serviceCollection.Add(new ServiceDescriptor(serviceType.Attribute!.ContractType, serviceType.Type,
            serviceType.Attribute.Lifetime));
   }

   private void RunTaskListFromConfig(string taskListName)
   {
      CheckInitialized();

      var taskList = new List<string>();
      configurationRoot.Bind(taskListName, taskList);
      RunTasksList(taskList);
   }

   private void RunTasksList(IEnumerable<string> taskList)
   {
      CheckInitialized();

      foreach (var taskName in taskList)
      {
         var task = FindTask(rootConfig.Tasks, taskName);
         if (task == null)
         {
            WriteLine(("*** Error: Task ", Red), ($" {taskName} ", Blue), ("not found!", Red));
            break;
         }

         task.OutputToConsole = false;
         if (!RunTask(task))
            break;
      }
   }

   private TaskConfig? FindTask(IReadOnlyCollection<TaskConfig> tasks, string taskName)
   {
      var task = tasks.FirstOrDefault(t => t.Name == taskName);

      if (task != null)
         return task;

      foreach (var t in tasks)
      {
         if (t.Tasks.Count > 0)
            task = FindTask(t.Tasks, taskName);

         if (task != null)
            return task;
      }

      return null;
   }

   private bool RunTask(TaskConfig itemInfo, object? options = null)
   {
      CheckInitialized();

      var taskError = false;
      var sw        = new Stopwatch();
      try
      {
         if (nestingLevel < 1)
         {
            WriteLine($"--------------------------------------------------------", Yellow);
            WriteLine(("*** Starting ", Yellow), ($" {itemInfo.Name} ", itemInfo.Color));
         }
         else
         {
            WriteLine(($"**** {new string('*', nestingLevel)} Starting child", Green),
               ($" {itemInfo.Name} ", itemInfo.Color));
         }

         var taskType         = runnableTypes[itemInfo.TaskClass!];
         var optionsAttribute = (OptionsAttribute?)taskType.GetCustomAttribute(typeof(OptionsAttribute));
         if (optionsAttribute != null && options == null)
         {
            options = Activator.CreateInstance(optionsAttribute.OptionType)!;
            BindRecursive(itemInfo, options);
            serviceCollection.Replace(new ServiceDescriptor(optionsAttribute.OptionType, options));

            void BindRecursive(TaskConfig config, object options)
            {
               if (config.ParentTask != null)
                  BindRecursive(config.ParentTask, options);
               if (!string.IsNullOrEmpty(config.ConfigPath))
                  configurationRoot.GetSection(config.ConfigPath)
                     .Bind(options, o => o.ErrorOnUnknownConfiguration = false);
            }
         }

         if (options != null) serviceCollection.Replace(new ServiceDescriptor(options.GetType(), options));

         using var provider =
            serviceCollection.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true });
         using var scope = provider.CreateScope();
         var       task  = (IRunnable)scope.ServiceProvider.GetService(taskType)!;
         if (task is IOutputRunnable to)
         {
            to.OutputToConsole   = itemInfo.OutputToConsole;
            to.BaseOutputPath    = itemInfo.BaseOutputPath;
            to.CleanFilesPattern = itemInfo.CleanFilesPattern;
            to.Interactive       = Interactive;
         }

         if (task is IRunnableConfirmation co && Interactive)
         {
            sw.Stop();
            if (!co.GetUserConfirmation())
               WriteLine(("*** Task was canceled ", Yellow), ($" {itemInfo.Name} ", Blue));
         }

         try
         {
            if (Interlocked.Increment(ref nestingLevel) <= taskMaxNestingLevel)
            {
               sw.Start();
               task.Run();
            }
            else
            {
               WriteLine(
                  $"Error running {(itemInfo.Name, Blue)}: Error:{($"Maximum Task nesting level of {taskMaxNestingLevel} was exceeded", Red)}",
                  DarkRed);
            }
         }
         catch (OperationCanceledException)
         {
            WriteLine(("*** Task was aborted ", Yellow), ($" {itemInfo.Name} ", Blue));
            taskError = true;
         }
         finally
         {
            Interlocked.Decrement(ref nestingLevel);
            sw.Stop();
         }
      }
      catch (Exception ex) when (Interactive)
      {
         WriteLine($"Error running {(itemInfo.Name, Blue)}: Error:{(ex.Message, Red)}", DarkRed);
         WriteLine($"Detail: {ex}", DarkYellow);
         taskError = true;
      }

      WriteLine();
      WriteLine(("Task", Yellow), ($" {itemInfo.Name} ", Blue), ("completed", Green), (" in", Yellow),
         ($" {sw.Elapsed.Humanize(2)}", Green));
      return !taskError;
   }
}