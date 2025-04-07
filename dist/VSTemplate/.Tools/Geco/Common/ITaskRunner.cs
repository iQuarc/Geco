namespace Geco.Common;

/// <summary>
///    Represents the task runner. Can be used by tasks to trigger running additional child tasks.
/// </summary>
public interface ITaskRunner
{
   /// <summary>
   ///    Runs the tasks with the given name and config object.
   ///    If the config is <c>null</c> then the config task config from the configuration file is used
   /// </summary>
   void RunTask(string taskName, object? config = null);

   /// <summary>
   ///    Runs a list of tasks by name
   /// </summary>
   /// <param name="taskNames"></param>
   void RunTasks(IEnumerable<string> taskNames);

   /// <summary>
   ///    Runs a list of tasks defined in the config file with the given task list name
   /// </summary>
   /// <param name="taskListName"></param>
   void RunNamedTaskList(string taskListName);

   /// <summary>
   ///    Lists a set of choices on the console and invokes the action associated to the one user chooses and returns true,
   ///    or returns false if user chooses to quit
   /// </summary>
   /// <returns><c>true</c> if user makes a choices <c>false</c> otherwise</returns>
   bool Choose(IReadOnlyList<(FormattableString Choice, Action Action)> choices);
}