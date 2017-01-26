using Geco.Common.Metadata;

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
            this.CallOnMetadataLoad(db);
        }

        protected ModelGeneratorBase(IMetadataProvider provider, IInflector inf, string folder)
            : base(inf)
        {
            this.Provider = provider;
            this.Folder = folder;
            ReloadMetadata();
        }

        protected void ReloadMetadata()
        {
            var db = Provider.LoadMetadata();
            this.CallOnMetadataLoad(db);
            this.Db = db;
        }

        private void CallOnMetadataLoad(DatabaseMetadata db)
        {
            OnMetadataLoaded(db);
        }

        protected virtual void OnMetadataLoaded(DatabaseMetadata db)
        {

        }

        protected void OverrideMetadata(DatabaseMetadata db)
        {
            this.Db = db;
        }
    }
}