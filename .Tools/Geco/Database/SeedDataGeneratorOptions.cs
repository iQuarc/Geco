using System.Collections.Generic;

namespace Geco.Database
{
    public class SeedDataGeneratorOptions
    {
        public string ConnectionName { get; set; }
        public string OutputFileName { get; set; }
        public List<string> Tables { get; set; }
        public string TablesRegex { get; set; }
    }
}