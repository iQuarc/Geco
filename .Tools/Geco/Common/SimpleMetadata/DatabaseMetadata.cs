using System;
using System.Collections.Generic;

namespace Geco.Common.SimpleMetadata
{
    public class DatabaseMetadata : IFreezable
    {
        public DatabaseMetadata(string name, IReadOnlyDictionary<string, Type> typeMappings)
        {
            Schemas = new MetadataCollection<Schema>(this);
            TypeMappings = typeMappings;
            Name = name;
        }

        public string Name { get; }
        public MetadataCollection<Schema> Schemas { get; }
        public bool IsFrozen { get; private set; }

        public IReadOnlyDictionary<string, Type> TypeMappings { get; }

        /// <summary>
        /// Freezes current database metadata instance so it cannot be modified any more
        /// </summary>
        public void Freeze()
        {
            this.IsFrozen = true;
        }
    }
}