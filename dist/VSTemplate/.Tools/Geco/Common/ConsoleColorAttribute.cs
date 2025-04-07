namespace Geco.Common;

[AttributeUsage(AttributeTargets.Class)]
public class ConsoleColorAttribute(ConsoleColor consoleColor) : Attribute
{
   public ConsoleColor ConsoleColor { get; } = consoleColor;
}