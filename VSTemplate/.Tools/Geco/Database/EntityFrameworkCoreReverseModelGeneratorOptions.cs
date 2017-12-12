namespace Geco.Database
{
    public class EntityFrameworkCoreReverseModelGeneratorOptions
    {
        public string ConnectionName { get; set; }
        public string Namespace { get; set; }
        public bool OneFilePerEntity { get; set; }
        public bool JsonSerialization { get; set; }
        public bool GenerateComments { get; set; }
        public bool UseSqlServer { get; set; }
        public bool ConfigureWarnings { get; set; }
        public bool DisableCodeWarnings { get; set; }
        public bool GeneratedCodeAttribute { get; set; }
        public bool NetCore { get; set; }
        public string ContextName { get; set; }
    }
}