using System.Collections.Generic;

namespace Geco.Common.SimpleMetadata
{
    /// <summary>
    ///     Represents a metadata item
    /// </summary>
    public interface IMetadataItem
    {
        /// <summary>
        ///     The name of current metadata item
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     A mutable dictionary for additional metadata for current <see cref="MetadataItem" />
        /// </summary>
        IDictionary<string, string> Metadata { get; }
    }

    /// <summary>
    ///     Base class for all metadata items
    /// </summary>
    public abstract class MetadataItem : IMetadataItem, IMetadataItemWriter
    {
        private bool inRemove;

        /// <summary>
        ///     The name of current metadata item
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        ///     A mutable dictionary for additional metadata for current <see cref="MetadataItem" />
        /// </summary>
        public IDictionary<string, string> Metadata { get; } = new MetadataDictionary();

        void IMetadataItemWriter.Remove()
        {
            if (inRemove)
                return;
            try
            {
                inRemove = true;
                OnRemove();
            }
            finally
            {
                inRemove = false;
            }
        }

        /// <summary>
        ///     Called when item is to be removed from the metadata graph. This is where the current item should remove all links
        ///     from other items to itself.
        /// </summary>
        protected virtual void OnRemove()
        {
        }
    }


    internal static partial class MetadataExtensions
    {
        public static T WithMetadata<T>(this T target, IMetadataItem medatata)
            where T : IMetadataItem
        {
            foreach (var (key, val) in medatata.Metadata) target.Metadata.Add(key, val);
            return target;
        }
    }
}