namespace Geco.Common
{
    /// <summary>
    /// Represents a runable task, for code generation or purposes or others
    /// </summary>
    public interface IRunnable
    {



        /// <summary>
        /// Invoked when this task is executed
        /// </summary>
        void Run();
    }

    /// <summary>
    /// Represents a runable task that outputs files to a location
    /// </summary>
    public interface IOutputRunnable : IRunnable
    {

        /// <summary>
        /// <c>true</c> if the task output should be mirrored to the console. <c>false</c> otherwise
        /// </summary>
        bool OutputToConsole { get; set; }
        /// <summary>
        /// Base path which will be combined with the file names of the files output by this task.
        /// </summary>
        string BaseOutputPath { get; set; }
        /// <summary>
        /// A wild card base pattern for deleting the files from the <see cref="BaseOutputPath"/> prior to generation. 
        /// </summary>
        string CleanFilesPattern { get; set; }
    }


    public interface IRunableConfirmation
    {
        string ConfirmationQuestion { get; }
        void Answer(string answer);
    }
}