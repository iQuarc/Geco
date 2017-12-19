using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Geco.Common;
using Geco.Common.SimpleMetadata;
using Microsoft.Extensions.Options;
using System.Text;

// ReSharper disable PossibleMultipleEnumeration

namespace Geco.Database
{
    /// <summary>
    /// Model Generator for Entity Framework Core
    /// </summary>
    [Options(typeof(EntityFrameworkCoreReverseModelGeneratorOptions))]
    public class EntityFrameworkCoreReverseModelGenerator : BaseGeneratorWithMetadata
    {
        private readonly EntityFrameworkCoreReverseModelGeneratorOptions options;

        public EntityFrameworkCoreReverseModelGenerator(IMetadataProvider provider, IInflector inf, EntityFrameworkCoreReverseModelGeneratorOptions options) : base(provider, inf, options.ConnectionName)
        {
            this.options = options;
        }

        protected override void Generate()
        {
            IgnoreUnsuportedColumns();
            WriteEntityFiles();
            WriteContextFile();
        }

        private void IgnoreUnsuportedColumns()
        {
            foreach (var schema in Db.Schemas)
                foreach (var table in schema.Tables)
                {
                    foreach (var column in table.Columns.ToList())
                        if (!Db.TypeMappings.TryGetValue(column.DataType, out var type) || type == null)
                        {
                            ColorConsole.WriteLine(
                                $"Column [{schema.Name}].[{table.Name}].[{column.Name}] has unsupported data type [{column.DataType}] and was Ignored.",
                                ConsoleColor.DarkYellow);
                            table.Columns.GetWritable().Remove(column.Name);
                        }

                    if (!table.Columns.Any(c => c.IsKey))
                    {
                        schema.Tables.GetWritable().Remove(table.Name);
                        foreach (var col in Db.Schemas.SelectMany(s => s.Tables.SelectMany(t => t.Columns)).Where(c => c.ForeignKey?.TargetTable == table))
                            col.ForeignKey.TargetTable.IncomingForeignKeys.GetWritable().Remove(col.ForeignKey.Name);
                        foreach (var fk in Db.Schemas.SelectMany(s => s.Tables.SelectMany(t => t.ForeignKeys)).Where(fk => fk.TargetTable == table))
                            fk.ParentTable.ForeignKeys.GetWritable().Remove(fk.Name);
                        foreach (var fk in Db.Schemas.SelectMany(s => s.Tables.SelectMany(t => t.IncomingForeignKeys)).Where(fk => fk.ParentTable == table))
                            fk.TargetTable.IncomingForeignKeys.GetWritable().Remove(fk.Name);

                        ColorConsole.WriteLine(
                            $"Table [{schema.Name}].[{table.Name}] does not have a primary key and was Ignored.",
                            ConsoleColor.DarkYellow);

                        continue;
                    }
                }
        }

        private void WriteEntityFiles()
        {
            using (BeginFile($"{options.ContextName ?? Inf.Pascalise(Db.Name)}Entities.cs", options.OneFilePerEntity == false))
            using (WriteHeader(options.OneFilePerEntity == false))
                foreach (var table in Db.Schemas.SelectMany(s => s.Tables).OrderBy(t => t.Name))
                {
                    var className = Inf.Pascalise(Inf.Singularise(table.Name));
                    table.Metadata["Class"] = className;

                    using (BeginFile($"{className}.cs", options.OneFilePerEntity))
                    using (WriteHeader(options.OneFilePerEntity))
                    {
                        WriteEntity(table);
                    }
                }
        }


        private void WriteContextFile()
        {
            using (BeginFile($"{options.ContextName ?? Inf.Pascalise(Db.Name)}.cs"))
            using (WriteHeader())
            {
                W($"[GeneratedCode(\"Geco\", \"{Assembly.GetEntryAssembly().GetName().Version}\")]", options.GeneratedCodeAttribute);
                W($"public partial class {options.ContextName ?? Inf.Pascalise(Db.Name)}Context : DbContext");
                WI("{");
                {
                    if (options.NetCore)
                    {
                        W("public IConfigurationRoot Configuration {get;}");
                        W();
                        W(
                            $"public {options.ContextName ?? Inf.Pascalise(Db.Name)}Context(IConfigurationRoot configuration)");
                        WI("{");
                        W("this.Configuration = configuration;");
                        DW("}");
                        W();
                    }

                    W("protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
                    WI("{");
                    WI("if (optionsBuilder.IsConfigured)");
                    {
                        W("return;");
                    }
                    DW();

                    if (options.UseSqlServer)
                    {
                        W($"optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings[\"{options.ConnectionName}\"].ConnectionString, opt =>", !options.NetCore);
                        W($"optionsBuilder.UseSqlServer(Configuration.GetConnectionString(\"{options.ConnectionName}\"), opt =>", options.NetCore);
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
                    {
                        WriteDbSets();
                    }
                    W();
                    W("protected override void OnModelCreating(ModelBuilder modelBuilder)");
                    WI("{");
                    {
                        WriteModelBuilderConfigurations();
                    }
                    DW("}");
                }
                DW("}");
            }
        }

        private IDisposable WriteHeader(bool write = true)
        {
            if (!write)
                return base.OnBlockEnd();

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
            W("using System;");
            W("using System.CodeDom.Compiler;");
            W("using System.Collections.Generic;");
            W("using Microsoft.Extensions.Configuration;", options.NetCore);
            W("using Microsoft.EntityFrameworkCore;");
            W("using Microsoft.EntityFrameworkCore.Diagnostics;");
            W("using Newtonsoft.Json;", options.JsonSerialization);
            W();
            W($"namespace {options.Namespace}");
            WI("{");

            return base.OnBlockEnd(() =>
            {
                DW("}");
            });
        }

        private void WriteDbSets()
        {
            foreach (var table in Db.Schemas.SelectMany<Schema, Table>(s => s.Tables).OrderBy<Table, string>(t => t.Name))
            {
                var className = table.Metadata["Class"];
                var plural = Inf.Pluralise(className);
                table.Metadata["DbSet"] = plural;
                W($"public virtual DbSet<{className}> {plural} {{ get; set; }}");
            }
        }

        private void WriteEntity(Table table)
        {
            var existingNames = new HashSet<string>();
            var className = table.Metadata["Class"];
            var classInterfaces = "";
            int i = 1;
            existingNames.Add(className);

            W($"[GeneratedCode(\"Geco\", \"{Assembly.GetEntryAssembly().GetName().Version}\")]", options.GeneratedCodeAttribute);
            W($"public partial class {className}{(!String.IsNullOrWhiteSpace(classInterfaces) ? ": " + classInterfaces : "")}");
            WI("{");
            {
                var keyProperties = table.Columns.Where<Column>(c => c.IsKey);
                if (keyProperties.Any())
                {
                    W("// Key Properties", options.GenerateComments);
                    foreach (var column in keyProperties)
                    {
                        var propertyName = Inf.Pascalise(column.Name);
                        CheckClash(ref propertyName, existingNames, ref i);
                        column.Metadata["Property"] = propertyName;
                        W($"public {GetClrTypeName(column.DataType)}{GetNullable(column)} {propertyName} {{ get; set; }}");
                    }
                    W();
                }


                var scalarProperties = table.Columns.Where<Column>(c => !c.IsKey);
                if (scalarProperties.Any())
                {
                    W("// Scalar Properties", options.GenerateComments);
                    foreach (var column in scalarProperties)
                    {
                        var propertyName = Inf.Pascalise(column.Name);
                        CheckClash(ref propertyName, existingNames, ref i);
                        column.Metadata["Property"] = propertyName;
                        W($"public {GetClrTypeName(column.DataType)}{GetNullable(column)} {propertyName} {{ get; set; }}");
                    }
                    W();
                }

                if (table.ForeignKeys.Any())
                {
                    W("// Foreign keys", options.GenerateComments);
                    foreach (var fk in table.ForeignKeys.OrderBy(t => t.ParentTable.Name).ThenBy(t => t.FromColumns[0].Name))
                    {
                        var targetClassName = Inf.Pascalise(Inf.Singularise(fk.TargetTable.Name));
                        //var propertyName = Inf.Pascalise(Inf.Singularise(RemoveSuffix(column.Name)));

                        string propertyName;
                        if (table.ForeignKeys.Count(f => f.TargetTable == fk.TargetTable) > 1)
                            propertyName = Inf.Pluralise(targetClassName) + GetFkName(fk.ToColumns);
                        else
                            propertyName = Inf.Pluralise(targetClassName);

                        if (CheckClash(ref propertyName, existingNames, ref i))
                        {
                            propertyName = Inf.Pascalise(Inf.Pluralise(fk.TargetTable.Name)) + GetFkName(fk.FromColumns);
                            CheckClash(ref propertyName, existingNames, ref i);
                        }

                        fk.Metadata["NavProperty"] = propertyName;
                        foreach (var column in fk.FromColumns)
                        {
                            column.Metadata["NavProperty"] = propertyName;
                        }
                        W("[JsonIgnore]", options.JsonSerialization);
                        W($"public {targetClassName} {propertyName} {{ get; set; }}");
                    }
                    W();
                }

                if (table.IncomingForeignKeys.Any())
                {
                    W("// Reverse navigation", options.GenerateComments);
                    foreach (var fk in table.IncomingForeignKeys.OrderBy(t => t.ParentTable.Name).ThenBy(t => t.FromColumns[0].Name))
                    {
                        var targetClassName = Inf.Pascalise(Inf.Singularise(fk.ParentTable.Name));
                        string propertyName;
                        if (table.IncomingForeignKeys.Count(f => f.ParentTable == fk.ParentTable) > 1)
                            propertyName = Inf.Pluralise(targetClassName) + GetFkName(fk.FromColumns);
                        else
                            propertyName = Inf.Pluralise(targetClassName);

                        if (CheckClash(ref propertyName, existingNames, ref i))
                        {
                            propertyName = Inf.Pascalise(Inf.Pluralise(fk.ParentTable.Name)) + GetFkName(fk.FromColumns);
                            CheckClash(ref propertyName, existingNames, ref i);
                        }
                        fk.Metadata["Property"] = propertyName;
                        fk.Metadata["Type"] = targetClassName;
                        W("[JsonIgnore]", options.JsonSerialization);
                        W($"public List<{targetClassName}> {propertyName} {{ get; set; }}");
                    }
                    W();

                    W($"public {className}()");
                    WI("{");
                    {
                        foreach (var fk in table.IncomingForeignKeys.OrderBy<ForeignKey, string>(t => t.ParentTable.Name).ThenBy(t => t.FromColumns[0].Name))
                        {
                            W($"this.{fk.Metadata["Property"]} = new List<{fk.Metadata["Type"]}>();");
                        }
                    }
                    DW("}");
                }

            }
            DW("}");
            W("", !options.OneFilePerEntity);
        }

        private string GetFkName(IReadOnlyList<Column> fromColumns)
        {
            var sb = new StringBuilder();
            foreach (var fromCol in fromColumns)
            {
                sb.Append(Inf.Pascalise(Inf.Singularise(RemoveSuffix(fromCol.Name))));
            }
            return sb.ToString();
        }

        private void WriteModelBuilderConfigurations()
        {
            foreach (var table in Db.Schemas.SelectMany<Schema, Table>(s => s.Tables).OrderBy(t => t.Name))
            {
                var className = table.Metadata["Class"];
                W($"modelBuilder.Entity<{className}>(entity =>");
                WI("{");
                {
                    W($"entity.ToTable(\"{table.Name}\", \"{table.Schema.Name}\");");

                    if (table.Columns.Count<Column>(c => c.IsKey) == 1)
                    {
                        var col = table.Columns.First<Column>(c => c.IsKey);
                        W($"entity.HasKey(e => e.{col.Metadata["Property"]})");
                        SemiColon();
                    }
                    else if (table.Columns.Count<Column>(c => c.IsKey) > 1)
                    {
                        W($"entity.HasKey(e => new {{ {string.Join(", ", table.Columns.Where<Column>(c => c.IsKey).Select(c => "e." + c.Metadata["Property"]))} }});");
                    }

                    WI();
                    foreach (var column in table.Columns.Where<Column>(c => c.ForeignKey == null))
                    {
                        var propertyName = column.Metadata["Property"];
                        DW($"entity.Property(e => e.{propertyName})");
                        IW($".HasColumnName(\"{column.Name}\")");
                        W($".HasColumnType(\"{GetColumnType(column)}\")");
                        if (!String.IsNullOrEmpty(column.DefaultValue))
                        {
                            W($".HasDefaultValueSql(\"{RemoveExtraParantesis(column.DefaultValue)}\")");
                        }
                        if (IsString(column.DataType) && !column.IsNullable)
                        {
                            W($".IsRequired()");
                        }
                        if (IsString(column.DataType) && column.MaxLength != -1)
                        {
                            W($".HasMaxLength({column.MaxLength})");
                        }
                        if (column.DataType == "uniqueidentifier")
                        {
                            W(".ValueGeneratedOnAdd()");
                        }
                        if (column.IsIdentity)
                        {
                            W(".UseSqlServerIdentityColumn()");
                            W(".ValueGeneratedOnAdd()");
                        }
                        SemiColon();
                        W();
                    }

                    foreach (var fk in table.ForeignKeys)
                    {
                        var propertyName = fk.Metadata["NavProperty"];
                        var reverse = fk.Metadata["Property"];
                        DW($"entity.HasOne(e => e.{propertyName})");
                        IW($".WithMany(p => p.{reverse})");
                        W($".HasForeignKey(p => p.{fk.FromColumns[0].Name})", fk.FromColumns.Count == 1);
                        W($".HasForeignKey(p => new {{{string.Join(", ", fk.FromColumns.Select(c => "p." + c.Metadata["Property"]))}}})", fk.FromColumns.Count > 1);
                        W($".OnDelete(DeleteBehavior.{GetBehavior(fk.DeleteAction)})");
                        W($".HasConstraintName(\"{fk.Name}\")");
                        SemiColon();
                        W();
                    }
                    Dedent();
                }
                DW("});");
            }
        }

        private string GetBehavior(ForeignKeyAction fkDeleteAction)
        {
            switch (fkDeleteAction)
            {
                case ForeignKeyAction.NoAction:
                    return "Restrict";
                case ForeignKeyAction.Cascade:
                    return "Cascade";
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
            if (existingNames.Contains(propertyName))
            {
                propertyName += i++;
                existingNames.Add(propertyName);
                return true;
            }
            existingNames.Add(propertyName);
            return false;
        }

        private readonly HashSet<string> stringTypes = new HashSet<string>() { "nvarchar", "varchar", "char", "nchar" };
        private readonly HashSet<string> binaryTypes = new HashSet<string>() { "varbinary" };
        private readonly HashSet<string> numericTypes = new HashSet<string>() { "numeric", "decimal" };

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
            if (column.IsNullable && Db.TypeMappings[column.DataType].GetTypeInfo().IsPrimitive && Db.TypeMappings[column.DataType] != typeof(char))
            {
                return "?";
            }
            return "";
        }

        private string GetClrTypeName(string sqlType)
        {
            string sysType = "string";
            if (Db.TypeMappings.ContainsKey(sqlType))
            {
                var clrType = Db.TypeMappings[sqlType];
                if (clrType == typeof(char))
                    return sysType;

                sysType = GetCharpTypeName(clrType);
            }
            return sysType;
        }

        private string GetColumnType(Column column)
        {
            if (IsString(column.DataType))
            {
                return $"{column.DataType}({(column.MaxLength == -1 || column.MaxLength >= 8000 ? "MAX" : column.MaxLength.ToString())})";
            }

            if (IsBinary(column.DataType))
            {
                return $"{column.DataType}({(column.MaxLength == -1 ? "MAX" : column.MaxLength.ToString())})";
            }

            if (IsNumeric(column.DataType))
            {
                return $"{column.DataType}({column.Precision}, {column.Scale})";
            }

            return column.DataType;
        }

        private string RemoveExtraParantesis(string stringValue)
        {
            if (stringValue.StartsWith("(") && stringValue.EndsWith(")"))
                return RemoveExtraParantesis(stringValue.Substring(1, stringValue.Length - 2));
            return stringValue;
        }
    }
}