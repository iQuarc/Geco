namespace Geco.Common.SimpleMetadata
{
    public interface IMetadataProvider
    {
        /// <summary>
        ///     Loads meta data from a database
        /// </summary>
        /// <returns></returns>
        DatabaseMetadata LoadMetadata(bool freeze);
    }
}