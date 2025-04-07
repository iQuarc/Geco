using System.Text.RegularExpressions;

namespace Geco.Common.Util;

public static class ColorConsole
{
   private static readonly Regex               SplitRegex = new(@"{[\d:,-]+}", RegexOptions.Compiled);
   private static readonly Stack<ConsoleColor> Colors     = new();

   public static void WriteLine(FormattableString? value, ConsoleColor color)
   {
      if (value == null)
      {
         Console.WriteLine();
         return;
      }

      Write(value, color);
      WriteLine();
   }

   public static void WriteLine(params (string value, ConsoleColor color)[] values)
   {
      var currentColor = Console.ForegroundColor;
      try
      {
         foreach (var valueColorPair in values)
         {
            Console.ForegroundColor = valueColorPair.color;
            Console.Write(valueColorPair.value);
         }

         Console.WriteLine();
      }
      finally
      {
         Console.ForegroundColor = currentColor;
      }
   }

   public static void Write(FormattableString value, ConsoleColor color)
   {
      var parts = SplitRegex.Split(value.Format);
      for (var i = 0; i < parts.Length; i++)
      {
         Write(parts[i], color);
         if (i < value.ArgumentCount)
         {
            var arg = value.GetArgument(i);
            if (arg is (string val, ConsoleColor c))
               Write(val, c);
            else
               Write(arg?.ToString(), color);
         }
      }
   }

   private static void Write(string? value, ConsoleColor color)
   {
      if (string.IsNullOrEmpty(value))
         return;

      using (WithColor(color))
      {
         Console.Write(value);
      }
   }

   public static void Write(params (string value, ConsoleColor color)[] values)
   {
      foreach (var valueColorPair in values)
      {
         Console.ForegroundColor = valueColorPair.color;
         using (WithColor(valueColorPair.color))
         {
            Console.Write(valueColorPair.value);
         }
      }
   }

   private static DisposableAction WithColor(ConsoleColor color)
   {
      var current = Console.ForegroundColor;
      Console.ForegroundColor = color;
      return new DisposableAction(() => { Console.ForegroundColor = current; });
   }
}