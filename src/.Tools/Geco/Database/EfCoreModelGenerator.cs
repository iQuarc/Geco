using Geco.Common;
using Geco.Common.Metadata;
using Microsoft.Extensions.Options;

namespace Geco.Database
{
    /// <summary>
    /// 
    /// </summary>
    public class EfCoreModelGenerator : ModelGeneratorBase
    {
        public EfCoreModelGenerator(DatabaseMetadata db, IInflector inf, IOptions<EfCoreModelGeneratorOptions> options) : base(db, inf, options.Value.OutputPath)
        {

        }

        public EfCoreModelGenerator(IMetadataProvider provider, IInflector inf, string folder) : base(provider, inf, folder)
        {

        }

        public override void Generate()
        {

        }
    }


    public class EfCoreModelGeneratorOptions
    {
        public string OutputPath { get; set; }
    }
}