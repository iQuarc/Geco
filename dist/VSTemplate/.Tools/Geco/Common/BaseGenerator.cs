using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Geco.Common
{
    public abstract class BaseGenerator : IOutputRunnable, IRunnableConfirmation
    {
        private const string IndentString = "    ";
        private readonly HashSet<string> filesToDelete = new HashSet<string>();
        private int _indent;

        private TextWriter _tw;
        private bool commaNewLine;
        private bool initialized;

        protected BaseGenerator(IInflector inf)
        {
            Inf = inf;
        }

        protected IInflector Inf { get; }

        public bool OutputToConsole { get; set; }

        public void Run()
        {
            DetermineFilesToClean();
            Generate();
            CleanFiles();
        }

        public string BaseOutputPath { get; set; }
        public string CleanFilesPattern { get; set; }
        public bool Interactive { get; set; }

        public virtual bool GetUserConfirmation()
        {
            if (string.IsNullOrEmpty(CleanFilesPattern))
                return true;
            ColorConsole.Write(
                $"Clean all files with pattern [{(CleanFilesPattern, ConsoleColor.Yellow)}] in the target folder [{(Path.GetFullPath(BaseOutputPath), ConsoleColor.Yellow)}] (y/n)?",
                ConsoleColor.White);
            return string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
        }

        protected abstract void Generate();

        private void CleanFiles()
        {
            foreach (var filePath in filesToDelete) File.Delete(filePath);
        }

        private void DetermineFilesToClean()
        {
            if (!string.IsNullOrWhiteSpace(CleanFilesPattern) && Directory.Exists(BaseOutputPath))
                foreach (var file in Directory.EnumerateFiles(BaseOutputPath, CleanFilesPattern,
                    SearchOption.TopDirectoryOnly))
                    filesToDelete.Add(file);
        }

        protected IDisposable BeginFile(string file, bool option = true)
        {
            if (!option)
                return new DisposableAction(null);

            initialized = false;
            var fileName = Path.Combine(BaseOutputPath, file);
            EnsurePath(fileName);
            filesToDelete.Remove(fileName);
            _tw = File.CreateText(fileName);
            return _tw;
        }

        private void EnsurePath(string fileName)
        {
            var folders = Path.GetDirectoryName(fileName);
            if (!string.IsNullOrEmpty(folders))
                Directory.CreateDirectory(folders);
        }


        /// <summary>
        ///     Write semicolon ; on the previous line
        /// </summary>
        protected void SemiColon()
        {
            _tw.Write(";");
            if (OutputToConsole) Console.Write(";");
        }

        /// <summary>
        ///     Write comma , on the previous line
        /// </summary>
        protected void Comma()
        {
            _tw.Write(",");
            if (OutputToConsole) Console.Write(",");
        }

        /// <summary>
        ///     Write comma , on the previous line if a new line is written
        /// </summary>
        protected void CommaIfNewLine()
        {
            commaNewLine = true;
        }

        /// <summary>
        ///     Stops write comma , on the previous line if a line is written
        /// </summary>
        protected void NoCommaIfNewLine()
        {
            commaNewLine = false;
        }

        /// <summary>
        ///     Write line and increase indent
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void WI(string text = "", bool write = true)
        {
            W(text, write);
            if (write)
                Indent();
        }

        /// <summary>
        ///     Increase indent and write line
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void IW(string text = "", bool write = true)
        {
            if (write)
                Indent();
            W(text, write);
        }

        /// <summary>
        ///     Decrease indent and write line
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void DW(string text = "", bool write = true)
        {
            if (write)
                Dedent();
            W(text, write);
        }

        /// <summary>
        ///     Write line and decrease indent
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void WD(string text = "", bool write = true)
        {
            W(text, write);
            if (write)
                Dedent();
        }

        /// <summary>
        ///     Write line with current indent
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void W(string text = "", bool write = true)
        {
            if (!write)
                return;
            if (initialized)
            {
                if (commaNewLine)
                {
                    _tw.Write(",");
                    if (OutputToConsole) Console.Write(",");
                }

                _tw.WriteLine();
                if (OutputToConsole) Console.WriteLine();
            }
            else
            {
                initialized = true;
            }

            if (string.IsNullOrWhiteSpace(text))
                return;

            for (var i = 0; i < _indent; i++)
            {
                _tw.Write(IndentString);
                if (OutputToConsole) Console.Write(IndentString);
            }

            _tw.Write(text);
            if (OutputToConsole) Console.Write(text);
        }

        /// <summary>
        ///     Increase indent
        /// </summary>
        protected void Indent()
        {
            _indent++;
        }

        /// <summary>
        ///     Decrease indent
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

        protected IDisposable OnBlockEnd(Action action = null, bool write = true)
        {
            return new DisposableAction(write ? action : null);
        }

        private class DisposableAction : IDisposable
        {
            private readonly Action action;

            public DisposableAction(Action action)
            {
                this.action = action;
            }

            public void Dispose()
            {
                action?.Invoke();
            }
        }
    }
}