namespace Geco.Config
{
    public class TaskConfig
    {
        /// <summary>
        ///     Name of the task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Class name of task to run
        /// </summary>
        public string TaskClass { get; set; }

        public bool OutputToConsole { get; set; }
        public string BaseOutputPath { get; set; }
        public string CleanFilesPattern { get; set; }
        internal int ConfigIndex { get; set; }
    }
}