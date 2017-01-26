using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Geco.Common
{
    public abstract class BaseGenerator
    {
        private const string IndentString = "    ";

        protected string Folder;
        private TextWriter _tw;
        private int _indent;
        private bool initialized;

        protected BaseGenerator(IInflector inf)
        {
            Inf = inf;
        }

        protected IInflector Inf { get; }

        public bool OutputToConsole { get; set; }
        public abstract void Generate();

        protected IDisposable BeginFile(string file)
        {
            initialized = false;
            _tw = File.CreateText(Path.Combine(Folder, file));
            return _tw;
        }

        /// <summary>
        /// Write line and increase indent
        /// </summary>
        /// <param name="text"></param>
        protected void WI(string text = "")
        {
            W(text);
            Indent();
        }

        /// <summary>
        /// Write semicolon ; on the previous line
        /// </summary>
        protected void SemiColon()
        {
            _tw.Write(";");
            if (OutputToConsole) Console.Write(";");
        }

        /// <summary>
        /// Write comma , on the previous line
        /// </summary>
        protected void Comma()
        {
            _tw.Write(",");
            if (OutputToConsole) Console.Write(",");
        }

        /// <summary>
        /// Increase indent and write line
        /// </summary>
        /// <param name="text"></param>
        protected void IW(string text = "")
        {
            Indent();
            W(text);
        }

        /// <summary>
        /// Decrease indent and write line
        /// </summary>
        /// <param name="text"></param>
        protected void DW(string text = "")
        {
            Dedent();
            W(text);
        }

        /// <summary>
        /// Write line and decrease indent
        /// </summary>
        /// <param name="text"></param>
        protected void WD(string text = "")
        {
            W(text);
            Dedent();
        }

        /// <summary>
        /// Write line with current indent
        /// </summary>
        /// <param name="text"></param>
        protected void W(string text = "")
        {
            if (initialized)
            {
                _tw.WriteLine();
                if (OutputToConsole) Console.WriteLine();
            }
            else
                initialized = true;

            if (string.IsNullOrWhiteSpace(text))
                return;

            for (int i = 0; i < _indent; i++)
            {
                _tw.Write(IndentString);
                if (OutputToConsole) Console.Write(IndentString);
            }
            _tw.Write(text);
            if (OutputToConsole) Console.Write(text);
        }

        /// <summary>
        /// Increase indent
        /// </summary>
        protected void Indent()
        {
            _indent++;
        }

        /// <summary>
        /// Decrease indent
        /// </summary>
        protected void Dedent()
        {
            _indent--;
        }

        protected string CommaJoin(IEnumerable<string> values)
        {
            return string.Join(", ", values);
        }

        protected string CommaJoin<T>(IEnumerable<T> values, Func<T, string> selector)
        {
            return string.Join(", ", values.Select(selector));
        }
    }
}