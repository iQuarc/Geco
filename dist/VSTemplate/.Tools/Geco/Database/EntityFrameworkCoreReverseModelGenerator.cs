using System.IO;
using System.Reflection;
using System.Text;
using Geco.Common.Inflector;
using Geco.Common.Templates;
using Humanizer;
using Humanizer.Inflections;
using Microsoft.Extensions.Configuration;

// ReSharper disable PossibleMultipleEnumeration

namespace Geco.Database;

/// <summary>
///    Model Generator for Entity Framework Core
/// </summary>
[Options(typeof(EntityFrameworkCoreReverseModelGeneratorOptions))]
public class EntityFrameworkCoreReverseModelGenerator(
   IMetadataProvider                               provider,
   IInflector                                      inf,
   EntityFrameworkCoreReverseModelGeneratorOptions options,
   TemplateEngine                                  templateEngine)
   : BaseGeneratorWithMetadata(provider, inf,
      options.ConnectionName ?? throw new InvalidOperationException("ConnectionName is Required"))
{
   private readonly HashSet<string> binaryTypes  = ["varbinary"];
   private readonly HashSet<string> numericTypes = ["numeric", "decimal"];

   private readonly HashSet<string> stringTypes = ["nvarchar", "varchar", "char", "nchar"];

   static EntityFrameworkCoreReverseModelGenerator()
   {
      Vocabularies.Default.AddIrregular("Data", "Data");
      Vocabularies.Default.AddIrregular("Metadata", "Metadata");
      Vocabularies.Default.AddIrregular("Marketing", "Marketing");
      Vocabularies.Default.AddIrregular("Status", "Status");
      Vocabularies.Default.AddIrregular("Filtered", "Filtered");
      Vocabularies.Default.AddPlural("Stat", "Stats");
   }

   public TemplateEngine TemplateEngine { get; } = templateEngine;

   public string Ns => options.NullableCSharp ? "?" : "";

   protected override void Generate()
   {
      IgnoreUnsupportedColumns();
      ExcludeTables();
      PrepareMetadata();
      WriteEntityFiles();
      WritePartialFiles();
      WriteContextFile();
      WriteMappings();
   }

   private void PrepareMetadata()
   {
      options.ExcludeReverseNavigation.AddRange(options.Enums.Keys); // Exclude reverse navigation for enums by default

      foreach (var table in Db.Schemas.SelectMany(s => s.Tables).OrderBy(t => t.Name))
      {
         var existingNames = new HashSet<string>();
         var i             = 1;
         var className     = Inf.Pascalise(Inf.Singularise(table.Name));
         existingNames.Add(className);

         var excludeReverseNavigation = options.ExcludeReverseNavigation.Any(x => table.TableNameMatches(x));

         if (excludeReverseNavigation)
            table.Metadata["ExcludeReverseNavigation"] = "true";


         table.Metadata["ClassFull"] = options.EntityNamespace.GetValueOrDefault(className, className);
         table.Metadata["Class"]     = className;

         foreach (var column in table.Columns)
         {
            var propertyName = Inf.Pascalise(column.Name);
            CheckClash(ref propertyName, existingNames, ref i);
            column.Metadata["Property"] = propertyName;
         }

         // Determine Navigation names for outgoing navigation properties
         foreach (var fk in table.ForeignKeys.OrderBy(t => t.ParentTable.Name)
                     .ThenBy(t => t.FromColumns.First().Name))
         {
            var    targetClassName = Inf.Pascalise(Inf.Singularise(fk.TargetTable.Name));
            string propertyName;

            if (table.ForeignKeys.Count(f => f.TargetTable == fk.TargetTable) > 1 || fk.ParentTable == fk.TargetTable)
               propertyName = GetFkName(fk.FromColumns);
            else
               propertyName = Inf.Singularise(targetClassName);

            if (CheckClash(ref propertyName, existingNames, ref i))
            {
               propertyName = Inf.Pascalise(Inf.Singularise(fk.TargetTable.Name)) + GetFkName(fk.FromColumns);
               CheckClash(ref propertyName, existingNames, ref i);
            }

            if (options.NavigationNames.TryGetValue(propertyName, out var name))
               propertyName = name;

            fk.Metadata["NavProperty"] = propertyName;

            foreach (var column in fk.FromColumns)
               column.Metadata["NavProperty"] = propertyName;
         }

         // Determine Incoming navigation property names
         foreach (var fk in table.IncomingForeignKeys
                     .Where(f => !ForeignKeyMatchesPrimaryKey(f))
                     .OrderBy(t => t.ParentTable.Name)
                     .ThenBy(t => t.FromColumns.First().Name))
         {
            var    targetClassName = Inf.Pascalise(Inf.Singularise(fk.ParentTable.Name));
            string propertyName;

            if (table.IncomingForeignKeys.Count(f => f.ParentTable == fk.ParentTable) > 1)
               propertyName = Inf.Pluralise(targetClassName) + GetFkName(fk.FromColumns);
            else
               propertyName = Inf.Pluralise(targetClassName);

            if (CheckClash(ref propertyName, existingNames, ref i))
            {
               propertyName = Inf.Pascalise(Inf.Pluralise(fk.ParentTable.Name)) +
                              GetFkName(fk.FromColumns);

               CheckClash(ref propertyName, existingNames, ref i);
            }

            if (options.NavigationNames.TryGetValue(propertyName, out var name))
               propertyName = name;

            fk.Metadata["Property"] = propertyName;
            fk.Metadata["Type"]     = targetClassName;

            if (excludeReverseNavigation &&
                !options.ExcludeReverseNavigationExcept.Any(x => fk.ParentTable.TableNameMatches(x)))
               fk.Metadata["ExcludeReverseNavigation"] = "true";
         }

         // One to One navigation if the Incoming foreign Key is made of same Columns as the Primary Key
         foreach (var fk in table.IncomingForeignKeys
                     .Where(ForeignKeyMatchesPrimaryKey)
                     .OrderBy(t => t.ParentTable.Name)
                     .ThenBy(t => t.FromColumns.First().Name))
         {
            var    targetClassName = Inf.Pascalise(Inf.Singularise(fk.ParentTable.Name));
            string propertyName;

            if (table.IncomingForeignKeys.Count(f => f.ParentTable == fk.ParentTable) > 1)
               propertyName = Inf.Singularise(targetClassName) + GetFkName(fk.FromColumns);
            else
               propertyName = Inf.Singularise(targetClassName);

            if (CheckClash(ref propertyName, existingNames, ref i))
            {
               propertyName = Inf.Pascalise(Inf.Singularise(fk.ParentTable.Name)) +
                              GetFkName(fk.FromColumns);

               CheckClash(ref propertyName, existingNames, ref i);
            }

            if (options.NavigationNames.TryGetValue(propertyName, out var name))
               propertyName = name;

            fk.Metadata["Property"] = propertyName;
            fk.Metadata["Type"]     = targetClassName;

            if (excludeReverseNavigation &&
                !options.ExcludeReverseNavigationExcept.Any(x => fk.ParentTable.TableNameMatches(x)))
               fk.Metadata["ExcludeReverseNavigation"] = "true";
         }


         // Enums
         foreach (var optionsEnum in options.Enums)
            if (table.TableNameMatches(optionsEnum.Key))
            {
               table.Metadata["Enum"] = optionsEnum.Value;

               foreach (var column in table.Columns.Where(x => x.IsKey))
               {
                  column.Metadata["Enum"] = optionsEnum.Value;

                  foreach (var fromColumn in column.IncomingForeignKeys.SelectMany(x => x.FromColumns))
                     fromColumn.Metadata["Enum"] = optionsEnum.Value;
               }
            }
      }
   }

   private void WriteEntityFiles()
   {
      if (options.GenerateEntities)
         using (BeginFile($"{options.ContextName ?? Inf.Pascalise(Db.Name)}Entities.cs",
                   options.OneFilePerEntity == false))
         using (WriteHeader(options.OneFilePerEntity == false))
         {
            foreach (var table in GetFilteredTables().OrderBy(t => t.Name))
            {
               var className = table.Metadata["Class"];

               var folder = options.FolderPerSchema &&
                            !string.Equals(table.Schema.Name, "dbo", StringComparison.OrdinalIgnoreCase)
                  ? table.Schema.Name.Pascalize()
                  : "";

               using (BeginFile(Path.Combine(folder, $"{className}.cs"), options.OneFilePerEntity))
               using (WriteHeader(options.OneFilePerEntity))
               {
                  WriteEntity(table);
               }
            }
         }
   }

   private void WritePartialFiles()
   {
      if (options.GenerateEntities)
         using (BeginFile($"{options.ContextName ?? Inf.Pascalise(Db.Name)}Entities.Detachable.cs"))
         {
            W();
            W($"namespace {options.Namespace}");
            WI("{");

            foreach (var table in GetFilteredTables().OrderBy(t => t.Name))
            {
               var className = table.Metadata["Class"];

               W($"public partial class {className}: IDetachable");
               WI("{");

               {
                  W("void IDetachable.DetachRelated()");
                  WI("{");

                  {
                     foreach (var fk in table.IncomingForeignKeys
                                 .Where(ForeignKeyMatchesPrimaryKey)
                                 .OrderBy(t => t.ParentTable.Name)
                                 .ThenBy(t => t.FromColumns.First().Name))
                     {
                        var propertyName = fk.Metadata["Property"];
                        W($"this.{propertyName} = null;");
                     }

                     foreach (var fk in table.ForeignKeys.OrderBy(t => t.ParentTable.Name)
                                 .ThenBy(t => t.FromColumns.First().Name)
                                 .Where(t => !options.ExcludeNavigation.Any(x => t.TargetTable.TableNameMatches(x))))
                     {
                        var propertyName = fk.Metadata["NavProperty"];
                        W($"this.{propertyName} = null;");
                     }

                     foreach (var fk in table.IncomingForeignKeys
                                 .Where(f => f.Metadata["ExcludeReverseNavigation"] != "true")
                                 .Where(f => !ForeignKeyMatchesPrimaryKey(f))
                                 .OrderBy(t => t.ParentTable.Name)
                                 .ThenBy(t => t.FromColumns.First().Name))
                        W($"this.{fk.Metadata["Property"]}.Clear();");
                  }

                  DW("}");
               }

               DW("}");
            }

            DW("}");
         }
   }

   private void WriteContextFile()
   {
      if (options.GenerateContext)
      {
         var contextName = options.ContextName ?? Inf.Pascalise(Db.Name);

         using (BeginFile($"{contextName}Context.cs"))
         using (WriteHeader())
         {
            W($"[GeneratedCode(\"Geco\", \"{Assembly.GetEntryAssembly()!.GetName().Version}\")]",
               options.GeneratedCodeAttribute);
            W($"public partial class {contextName}Context : DbContext");
            WI("{");

            {
               W($"public {contextName}Context(DbContextOptions<{contextName}Context> options) : base(options)");
               WI("{");
               W("// ReSharper disable once VirtualMemberCallInConstructor");
               W("ChangeTracker.LazyLoadingEnabled = false;");
               DW("}");
               W();

               WriteDbSets();

               W();

               W("protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
               WI("{");
               WI("if (optionsBuilder.IsConfigured)");
               {
                  W("return;");
               }

               DW();

               if (options.UseSqlServer)
               {
                  W($"optionsBuilder.UseSqlServer(Configuration.GetConnectionString(\"{options.ConnectionName}\"), opt =>");
                  WI("{");
                  {
                     W("//opt.EnableRetryOnFailure();");
                  }
                  DW("});");
                  W();
               }

               if (options.ConfigureWarnings)
               {
                  W("optionsBuilder.ConfigureWarnings(w =>");
                  WI("{");
                  {
                     W("w.Ignore(RelationalEventId.AmbientTransactionWarning);");
                     W("w.Ignore(RelationalEventId.QueryClientEvaluationWarning);");
                  }
                  DW("});");
               }

               DW("}");
               W();

               if (!options.ConfigurationsInsideContext)
               {
                  W("protected override void OnModelCreating(ModelBuilder modelBuilder)");
                  WI("{");
                  W("modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);");
                  W("OnModelCreatingConf(modelBuilder);");
                  DW("}");
                  W();

                  W("protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)");
                  WI("{");
                  W("base.ConfigureConventions(configurationBuilder);");
                  W("OnConfigureConventions(configurationBuilder);");
                  DW("}");
                  W();
                  W("partial void OnModelCreatingConf(ModelBuilder modelBuilder);");
                  W("partial void OnConfigureConventions(ModelConfigurationBuilder configurationBuilder);");
                  W();
               }

               if (options is { ConfigurationsInsideContext: true, GenerateMappings: true })
               {
                  W("protected override void OnModelCreating(ModelBuilder modelBuilder)");
                  WI("{");
                  {
                     WriteModelBuilderConfigurations();
                  }
                  DW("}");
               }
            }
            DW("}");
         }
      }
   }

   private void WriteMappings()
   {
      if (options is { ConfigurationsInsideContext: false, GenerateMappings: true })
         foreach (var table in GetFilteredTables().OrderBy(t => t.Name))
         {
            var className = table.Metadata["Class"];
            var classFull = table.Metadata["ClassFull"];

            using (BeginFile($"{className}Builder.cs", options.GenerateMappings))
            using (WriteHeader())
            {
               W($"public partial class {className}Builder : IEntityTypeConfiguration<{classFull}>");
               WI("{");
               {
                  W($"public void Configure(EntityTypeBuilder<{classFull}> entity)");
                  WI("{");
                  {
                     WriteEntityConfiguration(table);
                  }
                  DW("}");
               }
               DW("}");
            }
         }
   }

   private IDisposable WriteHeader(bool write = true)
   {
      if (!write)
         return OnBlockEnd();

      if (options.DisableCodeWarnings)
      {
         W("// ReSharper disable RedundantUsingDirective");
         W("// ReSharper disable DoNotCallOverridableMethodsInConstructor");
         W("// ReSharper disable InconsistentNaming");
         W("// ReSharper disable PartialTypeWithSinglePart");
         W("// ReSharper disable PartialMethodWithSinglePart");
         W("// ReSharper disable RedundantNameQualifier");
         W("// ReSharper disable UnusedMember.Global");
         W("#pragma warning disable 1591    //  Ignore \"Missing XML Comment\" warning");
         W();
      }

      W("using System.CodeDom.Compiler;");
      W("using Microsoft.Extensions.Configuration;", options.GenerateMappings);
      W("using Microsoft.EntityFrameworkCore;", options.GenerateMappings || options.GenerateContext);
      W("using Microsoft.EntityFrameworkCore.Metadata.Builders;", options.GenerateMappings);

      W("using Newtonsoft.Json;", options.JsonSerialization);

      foreach (var additionalNamespace in options.AdditionalNamespaces)
         W($"using {additionalNamespace};");

      W();
      W($"namespace {options.Namespace}");
      WI("{");

      foreach (var modelNamespace in options.ModelNamespaces) W($"using {modelNamespace};");

      W("", options.ModelNamespaces.Count > 0);

      return OnBlockEnd(() => { DW("}"); });
   }

   private void WriteDbSets()
   {
      var tablesBySchema = GetFilteredTables().GroupBy(x => x.Schema).OrderBy(x => x.Key.Name);

      foreach (var tableGroup in tablesBySchema)
      {
         W();
         W($"// {tableGroup.Key.Name}");

         foreach (var table in tableGroup.OrderBy(x => x.Name))
         {
            var className = table.Metadata["Class"]!;
            var classFull = table.Metadata["ClassFull"];
            var plural    = Inf.Pluralise(className);
            table.Metadata["DbSet"] = plural;
            W($"public virtual DbSet<{className}> {plural} {{ get; set; }}", options.AdvancedGeneration == false);
            W($"public virtual DbSet<{classFull}> {plural} => Set<{classFull}>();", options.AdvancedGeneration);
         }
      }
   }

   private void WriteEntity(Table table)
   {
      var className       = table.Metadata["Class"];
      var classInterfaces = TemplateEngine.RunTemplate(options.ClassInterfaceTemplate, table, options);

      W($"[GeneratedCode(\"Geco\", \"{Assembly.GetEntryAssembly()!.GetName().Version}\")]", options.GeneratedCodeAttribute);
      W("[Serializable]", options.SerializableAttribute);
      W($"public partial class {className}{(!string.IsNullOrWhiteSpace(classInterfaces) ? ": " + classInterfaces : "")}");
      WI("{");

      {
         var keyProperties = table.Columns.Where(c => c.IsKey);

         if (keyProperties.Any())
         {
            W("// Key Properties", options.GenerateComments);
            foreach (var column in keyProperties)
            {
               var propertyName = column.Metadata["Property"];
               W($"public {GetClrTypeName(column)} {propertyName} {{ get; set; }}");
            }

            W();
         }

         var scalarProperties = table.Columns.Where(c => !c.IsKey && !options.ExcludedColumns.Contains(c.Name));

         if (scalarProperties.Any())
         {
            W("// Scalar Properties", options.GenerateComments);
            foreach (var column in scalarProperties)
            {
               var propertyName = column.Metadata["Property"];
               W($"public {GetClrTypeName(column)} {propertyName} {{ get; set; }}{TemplateEngine.RunTemplate("MemberInitialization", column, options)}");
            }

            W();
         }

         if (table.ForeignKeys.Any())
         {
            W("// Navigation properties", options.GenerateComments);
            foreach (var fk in table.ForeignKeys.OrderBy(t => t.ParentTable.Name)
                        .ThenBy(t => t.FromColumns.First().Name)
                        .Where(t => !options.ExcludeNavigation.Any(x => t.TargetTable.TableNameMatches(x))))
            {
               var targetClassName = Inf.Pascalise(Inf.Singularise(fk.TargetTable.Name));
               var propertyName    = fk.Metadata["NavProperty"];
               W("[JsonIgnore]", options.JsonSerialization);
               W($"public {targetClassName}{Ns} {propertyName} {{ get; set; }}");
               WP($" //{Pluralize("Column", fk.FromColumns)}: {CommaJoin(fk.FromColumns, c => c.Name)}, FK: {fk.Name}", options.GenerateComments);
            }

            W();
         }

         if (table.IncomingForeignKeys.Any(f => f.Metadata["ExcludeReverseNavigation"] != "true"))
         {
            // One to Many
            W("// Reverse navigation properties", options.GenerateComments);
            foreach (var fk in table.IncomingForeignKeys
                        .Where(f => f.Metadata["ExcludeReverseNavigation"] != "true")
                        .Where(f => !ForeignKeyMatchesPrimaryKey(f))
                        .OrderBy(t => t.ParentTable.Name)
                        .ThenBy(t => t.FromColumns.First().Name))
            {
               var propertyName    = fk.Metadata["Property"];
               var targetClassName = fk.Metadata["Type"];
               W("[JsonIgnore]", options.JsonSerialization);
               W($"public List<{targetClassName}> {propertyName} {{ get; set; }}");
            }

            // One to One
            foreach (var fk in table.IncomingForeignKeys
                        .Where(f => f.Metadata["ExcludeReverseNavigation"] != "true")
                        .Where(ForeignKeyMatchesPrimaryKey)
                        .OrderBy(t => t.ParentTable.Name)
                        .ThenBy(t => t.FromColumns.First().Name))
            {
               var propertyName    = fk.Metadata["Property"];
               var targetClassName = fk.Metadata["Type"];
               W("[JsonIgnore]", options.JsonSerialization);
               W($"public {targetClassName}{Ns} {propertyName} {{ get; set; }}");
            }

            W();

            W($"public {className}()");
            WI("{");

            {
               foreach (var fk in table.IncomingForeignKeys
                           .Where(f => f.Metadata["ExcludeReverseNavigation"] != "true")
                           .Where(f => !ForeignKeyMatchesPrimaryKey(f))
                           .OrderBy(t => t.ParentTable.Name)
                           .ThenBy(t => t.FromColumns.First().Name))
                  W($"this.{fk.Metadata["Property"]} = new List<{fk.Metadata["Type"]}>();");
            }

            DW("}");
         }
      }

      DW("}");
      W("", !options.OneFilePerEntity);
   }

   private string GetFkName(IEnumerable<Column> fromColumns)
   {
      var sb = new StringBuilder();

      foreach (var fromCol in fromColumns)
         sb.Append(Inf.Pascalise(Inf.Singularise(RemoveSuffix(fromCol.Name))));

      return sb.ToString();
   }

   private void WriteModelBuilderConfigurations()
   {
      foreach (var table in Db.Schemas.SelectMany(s => s.Tables).OrderBy(t => t.Name))
      {
         var className = table.Metadata["Class"];
         W($"modelBuilder.Entity<{className}>(entity =>");
         WI("{");

         {
            WriteEntityConfiguration(table);
         }

         DW("});");
      }
   }

   private void WriteEntityConfiguration(Table table)
   {
      W($"entity.ToTable(\"{table.Name}\", \"{table.Schema.Name}\");", table.Triggers.Count == 0);
      W($"entity.ToTable(\"{table.Name}\", \"{table.Schema.Name}\", tb => tb.HasTrigger(\"{table.Triggers.FirstOrDefault()?.Name}\"));", table.Triggers.Count > 0);

      if (table.Columns.Count(c => c.IsKey) == 1)
      {
         var col = table.Columns.First(c => c.IsKey);
         W($"entity.HasKey(e => e.{col.Metadata["Property"]})");
         SemiColon();
      }
      else if (table.Columns.Count(c => c.IsKey) > 1)
      {
         W($"entity.HasKey(e => new {{ {string.Join(", ", table.Columns.Where(c => c.IsKey).Select(c => "e." + c.Metadata["Property"]))} }});");
      }

      WI();

      foreach (var column in table.Columns.Where(c => c.ForeignKey == null))
      {
         var propertyName = column.Metadata["Property"];
         DW($"entity.Property(e => e.{propertyName})");
         IW($".HasColumnName(\"{column.Name}\")");
         W($".HasColumnType(\"{GetColumnType(column)}\")");

         if (!string.IsNullOrEmpty(column.DefaultValue) && (column.DataType != "bit" || column.IsNullable))
            W($".HasDefaultValueSql(\"{RemoveExtraParenthesis(column.DefaultValue)}\")");

         if (IsString(column.DataType) && !column.IsNullable)
            W(".IsRequired()");

         if (IsString(column.DataType) && column.MaxLength != -1)
            W($".HasMaxLength({column.MaxLength})");

         if (column.DataType == "uniqueidentifier")
            W(".ValueGeneratedOnAdd()");

         if (column.IsComputed) W($".HasComputedColumnSql({Quote(column.ComputedDefinition)})");

         if (column.IsIdentity) W(".UseIdentityColumn()");

         if (column.DataType == "timestamp") W(".IsRowVersion()");

         foreach (var columnType in options.ColumnTypes.Where(c => !string.IsNullOrEmpty(c.TypeConverter)))
            if ((!string.IsNullOrEmpty(columnType.ColumnName) && column.ColumnNameMatches(columnType.ColumnName))
                || (string.IsNullOrEmpty(columnType.ColumnName) && string.Equals(column.DataType, columnType.TypeName,
                   StringComparison.OrdinalIgnoreCase)))
            {
               W($".HasConversion({columnType.TypeConverter})", columnType.ValueComparer == null);
               W($".HasConversion({columnType.TypeConverter}, {columnType.ValueComparer})",
                  columnType.ValueComparer != null);
            }

         SemiColon();
         W();
      }

      // One to Many
      foreach (var fk in table.ForeignKeys
                  .Where(x => !ForeignKeyMatchesPrimaryKey(x))
                  .Where(t => !options.ExcludeNavigation.Any(x => t.TargetTable.TableNameMatches(x)))
                  .OrderBy(x => x.Name))
      {
         var propertyName = fk.Metadata["NavProperty"];
         var reverse      = fk.Metadata["Property"];
         DW($"entity.HasOne(e => e.{propertyName})");
         IW($".WithMany(p => p.{reverse})", fk.Metadata["ExcludeReverseNavigation"] != "true");
         IW(".WithMany()", fk.Metadata["ExcludeReverseNavigation"] == "true");
         W($".HasForeignKey(p => p.{fk.FromColumns.First().Name})", fk.FromColumns.Count == 1);
         W($".HasForeignKey(p => new {{{string.Join(", ", fk.FromColumns.OrderBy(x => x.Name).Select(c => "p." + c.Metadata["Property"]))}}})", fk.FromColumns.Count > 1);
         W($".OnDelete(DeleteBehavior.{GetBehavior(fk.DeleteAction)})");
         W($".HasConstraintName(\"{fk.Name}\")");
         SemiColon();
         W();
      }

      // One to One
      foreach (var fk in table.ForeignKeys
                  .Where(ForeignKeyMatchesPrimaryKey)
                  .Where(t => !options.ExcludeNavigation.Any(x => t.TargetTable.TableNameMatches(x)))
                  .OrderBy(x => x.Name))
      {
         var propertyName = fk.Metadata["NavProperty"];
         var reverse      = fk.Metadata["Property"];
         DW($"entity.HasOne(e => e.{propertyName})");
         IW($".WithOne(p => p.{reverse})");
         W($".HasForeignKey<{table.Metadata["Class"]}>(p => p.{fk.FromColumns.First().Name})", fk.FromColumns.Count == 1);
         W($".HasForeignKey<{table.Metadata["Class"]}>(p => new {{{string.Join(", ", fk.FromColumns.OrderBy(x => x.Name).Select(c => "p." + c.Metadata["Property"]))}}})", fk.FromColumns.Count > 1);
         W($".OnDelete(DeleteBehavior.{GetBehavior(fk.DeleteAction)})");
         W($".HasConstraintName(\"{fk.Name}\")");
         SemiColon();
         W();
      }

      Dedent();
   }

   private string GetBehavior(ForeignKeyAction fkDeleteAction)
   {
      switch (fkDeleteAction)
      {
         case ForeignKeyAction.NoAction:
            return "Restrict";

         case ForeignKeyAction.Cascade:
            return "ClientCascade";

         case ForeignKeyAction.SetNull:
            return "SetNull";

         case ForeignKeyAction.SetDefault:
            return "ClientSetNull";

         default:
            throw new ArgumentOutOfRangeException(nameof(fkDeleteAction), fkDeleteAction, null);
      }
   }

   private bool CheckClash(ref string propertyName, HashSet<string> existingNames, ref int i)
   {
      if (!existingNames.Add(propertyName))
      {
         propertyName += i++;
         existingNames.Add(propertyName);
         return true;
      }

      return false;
   }

   private bool IsString(string dataType)
   {
      return stringTypes.Contains(dataType.ToLower());
   }

   private bool IsBinary(string dataType)
   {
      return binaryTypes.Contains(dataType.ToLower());
   }

   private bool IsNumeric(string dataType)
   {
      return numericTypes.Contains(dataType.ToLower());
   }

   private string RemoveSuffix(string name)
   {
      if (name.EndsWith("id", StringComparison.OrdinalIgnoreCase))
         return name.Substring(0, name.Length - 2);

      return name;
   }

   private string GetNullable(Column column)
   {
      if (column.IsNullable && Db.TypeMappings[column.DataType] != typeof(char))
         return "?";

      return "";
   }

   private string GetClrTypeName(Column column)
   {
      var sysType = "string";

      foreach (var columnType in options.ColumnTypes)
         if (column.ColumnNameMatches(columnType.ColumnName))
            return columnType.TypeName + GetNullable(column);

      if (column.Metadata["Enum"] != null) return column.Metadata["Enum"] + GetNullable(column);

      if (Db.TypeMappings.ContainsKey(column.DataType))
      {
         var clrType = Db.TypeMappings[column.DataType];

         if (clrType == typeof(char))
            return sysType;

         sysType = GetCSharpTypeName(clrType) + GetNullable(column);
      }

      return sysType;
   }

   private string GetColumnType(Column column)
   {
      if (IsString(column.DataType))
         return
            $"{column.DataType}({(column.MaxLength == -1 || column.MaxLength >= 8000 ? "MAX" : column.MaxLength.ToString())})";

      if (IsBinary(column.DataType))
         return $"{column.DataType}({(column.MaxLength == -1 ? "MAX" : column.MaxLength.ToString())})";

      if (IsNumeric(column.DataType))
         return $"{column.DataType}({column.Precision}, {column.Scale})";

      return column.DataType;
   }

   private string RemoveExtraParenthesis(string stringValue)
   {
      if (stringValue.StartsWith("(") && stringValue.EndsWith(")"))
         return RemoveExtraParenthesis(stringValue.Substring(1, stringValue.Length - 2));

      return stringValue;
   }

   private void IgnoreUnsupportedColumns()
   {
      foreach (var schema in Db.Schemas)
      foreach (var table in schema.Tables)
      {
         foreach (var column in table.Columns.ToList())
            if (!Db.TypeMappings.TryGetValue(column.DataType, out var type) || type == null)
            {
               WriteLine($"Column {($"[{schema.Name}].[{table.Name}].[{column.Name}]", Yellow)} has unsupported data type {($"[{column.DataType}]", Yellow)} and was Ignored.", DarkYellow);
               table.Columns.GetWritable().Remove(column.Name);
            }

         if (!table.Columns.Any(c => c.IsKey))
         {
            WriteLine($"Table {($"[{schema.Name}].[{table.Name}]", Yellow)} does not have a primary key and was Ignored.", DarkYellow);

            table.GetWritable().Remove();
         }
      }
   }

   private void ExcludeTables()
   {
      if (options.Tables.Count == 0 && string.IsNullOrEmpty(options.TablesRegex) &&
          options.ExcludedTables.Count == 0 && string.IsNullOrEmpty(options.ExcludedTablesRegex))
         return;

      var tables = new HashSet<Table>(
         Db.Schemas.SelectMany(s => s.Tables)
            .Where(t => !options.ExcludedTables.Any(n => t.TableNameMatches(n))
                        && !t.TableNameMatchesRegex(options.ExcludedTablesRegex, false)));

      foreach (var schema in Db.Schemas)
      foreach (var table in schema.Tables)
         if (!tables.Contains(table))
         {
            if (options.Enums.Keys.Any(x => table.TableNameMatches(x)))
               options.FilteredTables.Add(table.FullyQualifiedName);
            else
               schema.Tables.GetWritable().Remove(table.Name);
         }
   }

   private HashSet<Table> GetFilteredTables()
   {
      var includeAll = options.Tables.Count == 0 && string.IsNullOrEmpty(options.TablesRegex);

      var tables = new HashSet<Table>(
         Db.Schemas.SelectMany(s => s.Tables)
            .Where(t => (options.Tables.Any(n => t.TableNameMatches(n)) ||
                         t.TableNameMatchesRegex(options.TablesRegex, false) || includeAll)
                        && !options.FilteredTables.Any(n => t.TableNameMatches(n))
                        && !t.TableNameMatchesRegex(options.ExcludedTablesRegex, false)));

      return tables;
   }

   public bool ForeignKeyMatchesPrimaryKey(ForeignKey foreignKey)
   {
      return foreignKey.FromColumns.All(x => x.IsKey) &&
             foreignKey.FromColumns.Count == foreignKey.ParentTable.Columns.Count(x => x.IsKey);
   }
}