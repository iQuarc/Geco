using System;

namespace Geco.Common
{
    public class OptionsAttribute : Attribute
    {
        public OptionsAttribute(Type optionsType)
        {
            OptionType = optionsType ?? throw new ArgumentNullException(nameof(optionsType));
        }

        public Type OptionType { get; }
    }
}