namespace Geco.Common.SimpleMetadata
{
    public interface IMetadataProvider
    {
        /// <summary>
        ///     Loads meta data from a database and caches it
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        DatabaseMetadata GetMetadata(string connectionName = "DefaultConnection");

        /// <summary>
        ///     Reloads the metadata from the database and caches it
        /// </summary>
        void Reload();
    }
}