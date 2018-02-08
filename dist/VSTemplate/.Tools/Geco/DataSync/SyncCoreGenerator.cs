using Geco.Common;

namespace Geco.DataSync
{
    /// <summary>
    /// Generates sync infrastructure code
    /// </summary>
    [Options(typeof(SyncCoreGeneratorOptions))]
    public class SyncCoreGenerator : BaseGenerator
    {
        public SyncCoreGenerator(IInflector inf) : base(inf)
        {
        }

        protected override void Generate()
        {
            throw new System.NotImplementedException();
        }
    }
}