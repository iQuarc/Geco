namespace Geco.Common;

/// <summary>
///    A helper task that runs a list of other tasks. Can be used as a base class for composite tasks
/// </summary>
[Options(typeof(TaskListRunnerOptions))]
[ConsoleColor(Cyan)]
public class TaskListRunner(ITaskRunner taskRunner, TaskListRunnerOptions options) : IRunnable
{
   protected ITaskRunner TaskRunner { get; } = taskRunner;

   public void Run()
   {
      WriteLine(($" [{options.Count}] ", Blue), ("child tasks to run: ", Yellow));
      foreach (var childTask in options.WithInfo())
         WriteLine(($"    {childTask.Index + 1}. ", White), ($"{childTask.Item}", DarkBlue));
      Run(options);
   }

   protected virtual void Run(TaskListRunnerOptions taskList)
   {
      TaskRunner.RunTasks(options);
   }
}