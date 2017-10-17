namespace Geco.Config
{
    public class TaskConfig
    {
        public string Name { get; set; }
        public string Generator { get; set; }
        public bool OutputToConsole { get; set; }
        public string BaseOutputPath { get; set; }
        public string CleanFilesPattern { get; set; }
        internal int ConfigIndex { get; set; }
    }
}