using System.Collections.Generic;

namespace Geco.Config
{
    public class RootConfig
    {
        public List<TaskConfig> Tasks { get; } = new List<TaskConfig>();
    }
}