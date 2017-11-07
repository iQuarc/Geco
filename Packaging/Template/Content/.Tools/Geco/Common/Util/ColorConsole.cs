using System;

namespace Geco.Common
{
    public static class ColorConsole
    {
        public static void WriteLine(string value, ConsoleColor color)
        {
            var curentColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(value);
            }
            finally
            {
                Console.ForegroundColor = curentColor;
            }
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


        public static void Write(string value, ConsoleColor color)
        {
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