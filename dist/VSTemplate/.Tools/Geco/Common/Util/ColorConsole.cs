using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Geco.Common
{
    public static class ColorConsole
    {
        static readonly Regex splitRegex = new Regex(@"{\d+}", RegexOptions.Compiled);

        public static void WriteLine(FormattableString value, ConsoleColor color)
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
            var curentColor = Console.ForegroundColor;
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
                Console.ForegroundColor = curentColor;
            }
        }

        public static void Write(FormattableString value, ConsoleColor color)
        {

            var parts = splitRegex.Split(value.Format);
            for (int i = 0; i < parts.Length; i++)
            {
                Write(parts[i], color);
                if (i < value.ArgumentCount)
                {
                    var arg = value.GetArgument(i);
                    if (arg is ITuple v && v.Length == 2 && v[1] is ConsoleColor c)
                        Write(v[0].ToString(), c);
                    else
                        Write(arg.ToString(), color);
                }
            }
        }

        private static void Write(string value, ConsoleColor color)
        {
            if (string.IsNullOrEmpty(value))
                return;
            var curentColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.Write(value);
            }
            finally
            {
                Console.ForegroundColor = curentColor;
            }
        }

        public static void Write(params (string value, ConsoleColor color)[] values)
        {
            var curentColor = Console.ForegroundColor;
            try
            {
                foreach (var valueColorPair in values)
                {
                    Console.ForegroundColor = valueColorPair.color;
                    Console.Write(valueColorPair.value);
                }
            }
            finally
            {
                Console.ForegroundColor = curentColor;
            }
        }
    }
}