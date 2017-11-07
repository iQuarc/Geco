using System.Collections.Generic;

namespace Geco.Database
{
    public class SeedScriptRunnerOptions
    {
        public string ConnectionName { get; set; }
        public List<string> Files { get; } = new List<string>();
        public int CommandTimeout { get; set; } = 60;
    }
}