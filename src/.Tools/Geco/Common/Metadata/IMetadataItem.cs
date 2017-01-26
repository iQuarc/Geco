using System;
using System.Collections.Generic;

namespace Geco.Common.Metadata
{
    /// <summary>
    /// Represents a metadata item
    /// </summary>
    public interface IMetadataItem
    {
        /// <summary>
        /// The name of current metadata item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A mutable dictionary for additional metadata for current <see cref="MetadataItem"/>
        /// </summary>
        IDictionary<string, string> Metadata { get; }
    }

    /// <summary>
    /// Base class for all metadata items
    /// </summary>
    public abstract class MetadataItem : IMetadataItem, IFreezableOwner
    {
        /// <summary>
        /// The name of current metadata item
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// A mutable dictionary for additional metadata for current <see cref="MetadataItem"/>
        /// </summary>
        public IDictionary<string, string> Metadata { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Indicates that the current instance was frozen for any modifications
        /// </summary>
        public abstract bool IsFrozen { get; }
    }

    /// <summary>
    /// Indicates that the current instance is a freezable object that can be frozen to prevent all modifications
    /// </summary>
    public interface IFreezableOwner
    {
        /// <summary>
        /// Indicates if current instance was frozen
        /// </summary>
        bool IsFrozen { get; }
    }
}