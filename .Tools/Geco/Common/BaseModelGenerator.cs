using System;
using Geco.Common.SimpleMetadata;

namespace Geco.Common
{
    public abstract class ModelGeneratorBase : BaseGenerator
    {
        public DatabaseMetadata Db { get; private set; }
        public IMetadataProvider Provider { get; }

        protected ModelGeneratorBase(DatabaseMetadata db, IInflector inf, string folder)
            :base(inf)
        {
            this.Db = db;
            this.Folder = folder;
        }

        protected ModelGeneratorBase(IMetadataProvider provider, IInflector inf, string folder)
            : base(inf)
        {
            this.Provider = provider;
            this.Folder = folder;
        }

        protected void ReloadMetadata()
        {
            if (Provider != null)
                this.Db = Provider.LoadMetadata(false);
            this.OnMetadataLoaded(Db);
            this.Db.Freeze();
        }

        protected virtual void OnMetadataLoaded(DatabaseMetadata db)
        {

        }

        protected override void Initialize()
        {
            ReloadMetadata();
        }

        protected void OverrideMetadata(DatabaseMetadata db)
        {
            this.Db = db;
        }

        protected string GetCharpTypeName(Type type)
        {
            if (type == typeof(bool)) return "bool";
            if (type == typeof(byte)) return "byte";
            if (type == typeof(sbyte)) return "sbyte";
            if (type == typeof(char)) return "char";
            if (type == typeof(decimal)) return "decimal";
            if (type == typeof(double)) return "double";
            if (type == typeof(float)) return "float";
            if (type == typeof(int)) return "int";
            if (type == typeof(uint)) return "uint";
            if (type == typeof(long)) return "long";
            if (type == typeof(ulong)) return "ulong";
            if (type == typeof(object)) return "object";
            if (type == typeof(short)) return "short";
            if (type == typeof(ushort)) return "ushort";
            if (type == typeof(string)) return "string";
            return type.Name;
        }
    }
}