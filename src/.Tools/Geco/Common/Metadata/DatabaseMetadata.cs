namespace Geco.Common.Metadata
{
    public class DatabaseMetadata : IFreezableOwner
    {
        public DatabaseMetadata()
        {
            Schemas = new MetadataCollection<Schema>(this);
        }

        public MetadataCollection<Schema> Schemas { get; }
        public bool IsFrozen { get; private set; }

        /// <summary>
        /// Freezes current database metadata instance so it cannot be modified any more
        /// </summary>
        public void Freeze()
        {
            this.IsFrozen = true;
        }
    }
}