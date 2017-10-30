using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Geco.Common
{
    public abstract class BaseGenerator : IOutputRunnable
    {
        private const string IndentString = "    ";

        private TextWriter _tw;
        private int _indent;
        private bool initialized;
        private readonly HashSet<string> filesToDelete = new HashSet<string>();

        protected BaseGenerator(IInflector inf)
        {
            Inf = inf;
        }

        protected IInflector Inf { get; }

        public bool OutputToConsole { get; set; }
        protected abstract void Generate();

        public void Run()
        {
            DetermineFilesToClean();
            Generate();
            CleanFiles();
        }

        private void CleanFiles()
        {
            foreach (var filePath in filesToDelete)
            {
                File.Delete(filePath);
            }
        }

        private void DetermineFilesToClean()
        {
            if (!String.IsNullOrWhiteSpace(CleanFilesPattern) && Directory.Exists(BaseOutputPath))
                foreach (var file in Directory.EnumerateFiles(BaseOutputPath, CleanFilesPattern, SearchOption.AllDirectories))
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
            if (!String.IsNullOrEmpty(folders))
                Directory.CreateDirectory(folders);
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
        /// Write line and increase indent
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void WI(string text = "", bool write = true)
        {
            W(text);
            Indent();
        }

        /// <summary>
        /// Increase indent and write line
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void IW(string text = "", bool write = true)
        {
            Indent();
            W(text);
        }

        /// <summary>
        /// Decrease indent and write line
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void DW(string text = "", bool write = true)
        {
            Dedent();
            W(text);
        }

        /// <summary>
        /// Write line and decrease indent
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void WD(string text = "", bool write = true)
        {
            W(text, write);
            Dedent();
        }

        /// <summary>
        /// Write line with current indent
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="write">boolean parameter to indicate if the text should be written or not</param>
        protected void W(string text = "", bool write = true)
        {
            if (!write)
                return;
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

        public string BaseOutputPath { get; set; }
        public string CleanFilesPattern { get; set; }

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