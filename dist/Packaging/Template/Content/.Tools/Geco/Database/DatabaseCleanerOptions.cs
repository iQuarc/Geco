namespace Geco.Database
{
    public class DatabaseCleanerOptions
    {
        public string ConnectionName { get; set; }
        public int CommandTimeout { get; set; } = 60;
    }
}