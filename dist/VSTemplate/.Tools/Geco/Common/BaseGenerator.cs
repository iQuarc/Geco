using System.Diagnostics;
using System.IO;
using Geco.Common.Inflector;
using Humanizer;

namespace Geco.Common;

public abstract class BaseGenerator(IInflector inf)
   : IOutputRunnable, IRunnableConfirmation
{
   private const    string          IndentString  = "    ";
   private readonly HashSet<string> filesToDelete = new();
   private          bool            commaNewLine;
   private          int             indent;
   private          bool            initialized;

   private TextWriter? tw;

   protected IInflector Inf { get; } = inf;

   public bool OutputToConsole { get; set; }

   public void Run()
   {
      DetermineFilesToClean();
      Generate();
      CleanFiles();
   }

   public string? BaseOutputPath    { get; set; }
   public string? CleanFilesPattern { get; set; }
   public bool    Interactive       { get; set; }

   public virtual bool GetUserConfirmation()
   {
      if (string.IsNullOrEmpty(BaseOutputPath))
         throw new InvalidOperationException($"{nameof(BaseOutputPath)} is null");

      if (string.IsNullOrEmpty(CleanFilesPattern))
         return true;

      Write($"Clean all files with pattern [{(CleanFilesPattern, Yellow)}] in the target folder [{(Path.GetFullPath(BaseOutputPath), Yellow)}] (y/n)?",
         White);

      return string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
   }

   protected abstract void Generate();

   private void CleanFiles()
   {
      foreach (var filePath in filesToDelete)
         File.Delete(filePath);
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
      string fileName;

      if (!Path.IsPathFullyQualified(file))
         fileName = Path.Combine(BaseOutputPath ?? ".", file);
      else
         fileName = file;

      EnsurePath(fileName);
      filesToDelete.Remove(fileName);
      tw = CreateFileWriter(fileName);
      return tw;
   }

   protected virtual TextWriter CreateFileWriter(string fileName)
   {
      return File.CreateText(fileName);
   }

   private void EnsurePath(string fileName)
   {
      var folders = Path.GetDirectoryName(fileName);

      if (!string.IsNullOrEmpty(folders))
         Directory.CreateDirectory(folders);
   }


   /// <summary>
   ///    Write semicolon ; on the previous line
   /// </summary>
   protected void SemiColon(bool write = true)
   {
      if (!write)
         return;

      tw?.Write(";");

      if (OutputToConsole)
         Console.Write(";");
   }

   /// <summary>
   ///    Write comma , on the previous line
   /// </summary>
   protected void Comma(bool write = true)
   {
      if (!write)
         return;

      tw?.Write(",");

      if (OutputToConsole)
         Console.Write(",");
   }

   public string? Quote(string? value)
   {
      if (value == null)
         return null;
      return $"\"{value}\"";
   }

   /// <summary>
   ///    Write comma , on the previous line if a new line is written with the same indent. Changing indent removes comma.
   /// </summary>
   protected void CommaIfNewLine()
   {
      commaNewLine = true;
   }

   /// <summary>
   ///    Stops write comma , on the previous line if a line is written
   /// </summary>
   protected void NoCommaIfNewLine()
   {
      commaNewLine = false;
   }

   /// <summary>
   ///    Write line and increase indent
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
   ///    Increase indent and write line
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
   ///    Decrease indent and write line
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
   ///    Write line and decrease indent
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
   ///    Write on Previous line
   /// </summary>
   /// <param name="text"></param>
   /// <param name="write"></param>
   protected void WP(string text, bool write = true)
   {
      if (write)
      {
         tw.Write(text);

         if (OutputToConsole)
            Console.Write(text);
      }
   }

   /// <summary>
   ///    Write line with current indent
   /// </summary>
   /// <param name="text">The text to write</param>
   /// <param name="writeIf">boolean parameter to indicate if the text should be written or not</param>
   protected void W(string text = "", bool writeIf = true)
   {
      if (!writeIf)
         return;

      if (initialized)
      {
         if (commaNewLine)
         {
            tw.Write(",");

            if (OutputToConsole)
               Console.Write(",");
         }

         tw.WriteLine();

         if (OutputToConsole)
            Console.WriteLine();
      }
      else
      {
         initialized = true;
      }

      if (string.IsNullOrWhiteSpace(text))
         return;

      for (var i = 0; i < indent; i++)
      {
         tw.Write(IndentString);

         if (OutputToConsole)
            Console.Write(IndentString);
      }

      tw.Write(text);

      if (OutputToConsole)
         Console.Write(text);
   }

   protected IDisposable StartAlignBlock(params string[] args)
   {
      if (args.Length == 0)
         args = [" ", "\t"];

      var block = new AlignBlock(this, args);

      return block;
   }

   /// <summary>
   ///    Increase indent
   /// </summary>
   protected void Indent()
   {
      indent++;
      commaNewLine = false;
   }

   /// <summary>
   ///    Decrease indent
   /// </summary>
   protected void Dedent()
   {
      indent--;
      Debug.Assert(indent >= 0);
      commaNewLine = false;
   }

   /// <summary>
   ///    Returns a string with comma joined values
   /// </summary>
   protected string CommaJoin(IEnumerable<string> values)
   {
      return string.Join(", ", values);
   }

   /// <summary>
   ///    Returns a string with comma joined values
   /// </summary>
   protected string CommaJoin<T>(IEnumerable<T> values, Func<T, string> selector)
   {
      return string.Join(", ", values.Select(selector));
   }

   /// <summary>
   ///    Pluralizes the input term if collection contains more than one element
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="inputTern">The input term singular</param>
   /// <param name="collection">The collection that determines the pluralization</param>
   /// <returns>The inputTerm pluralized if collection has more than 1 element, inputTerm unchanged otherwise</returns>
   public string Pluralize<T>(string inputTern, IReadOnlyCollection<T> collection)
   {
      if (collection?.Count > 1)
         return inputTern.Pluralize();

      return inputTern;
   }

   protected IDisposable OnBlockEnd(Action? action = null, bool write = true)
   {
      return new DisposableAction(write ? action : null);
   }

   private class AlignBlock : IDisposable
   {
      private readonly BaseGenerator baseGenerator;
      private readonly TextWriter?   originalWriter;
      private readonly string[]      splitBy;
      private readonly StringWriter  sw = new();

      public AlignBlock(BaseGenerator baseGenerator, string[] splitBy)
      {
         this.baseGenerator = baseGenerator;
         this.splitBy       = splitBy;
         originalWriter     = baseGenerator.tw;
         baseGenerator.tw   = Writer;
      }

      private TextWriter Writer => sw;

      public void Dispose()
      {
         AlignText();
         baseGenerator.tw = originalWriter;
      }

      private void AlignText()
      {
         var sb           = sw.GetStringBuilder();
         var offsets      = new List<int>();
         var segmentsList = new List<string?[]>();

         foreach (var line in sb.ToString().Split(sw.NewLine))
         {
            var segments = line.Split(splitBy,
               StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            segmentsList.Add(segments);

            for (var i = 0; i < segments.Length; i++)
            {
               if (offsets.Count <= i)
                  offsets.Add(0);

               if (segments[i].Length > offsets[i])
                  offsets[i] = segments[i].Length;
            }
         }

         foreach (var segements in segmentsList)
            for (var i = 0; i < segements.Length; i++)
            {
            }
      }
   }
}