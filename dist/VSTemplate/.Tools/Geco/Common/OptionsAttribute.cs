namespace Geco.Common;

[AttributeUsage(AttributeTargets.Class)]
public class OptionsAttribute(Type optionsType) : Attribute
{
   public Type OptionType { get; } = optionsType ?? throw new ArgumentNullException(nameof(optionsType));
}