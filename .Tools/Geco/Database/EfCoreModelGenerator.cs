using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Geco.Common;
using Geco.Common.SimpleMetadata;
using Microsoft.Extensions.Options;

namespace Geco.Database
{
    /// <summary>
    /// 
    /// </summary>
    public class EfCoreModelGenerator : ModelGeneratorBase
    {
        public EfCoreModelGenerator(DatabaseMetadata db, IInflector inf, IOptions<EfCoreModelGeneratorOptions> options) : base(db, inf, options.Value.OutputPath)
        {
        }

        public EfCoreModelGenerator(IMetadataProvider provider, IInflector inf, EfCoreModelGeneratorOptions options) : base(provider, inf, options.OutputPath)
        {

        }



        protected override void Generate()
        {
            WriteEntitiesFile();
            WriteContextFile();
        }

        private void WriteEntitiesFile()
        {
            using (BeginFile("SyncDbEntities.Generated.cs"))
            {
                W("// ReSharper disable RedundantUsingDirective");
                W("// ReSharper disable DoNotCallOverridableMethodsInConstructor");
                W("// ReSharper disable InconsistentNaming");
                W("// ReSharper disable PartialTypeWithSinglePart");
                W("// ReSharper disable PartialMethodWithSinglePart");
                W("// ReSharper disable RedundantNameQualifier");
                W("// TargetFrameworkVersion = 4.51");
                W("#pragma warning disable 1591    //  Ignore \"Missing XML Comment\" warning");
                W();
                W("using System;");
                W("using System.CodeDom.Compiler;");
                W("using System.Collections.Generic;");
                W("using Microsoft.EntityFrameworkCore;");
                W("using Microsoft.EntityFrameworkCore.Metadata;");
                W("using Newtonsoft.Json;");
                W();
                W("namespace Mira.Web.DataAccess.SyncContext");
                WI("{");
                {
                    WriteEntities();
                }
                DW("}");
            }
        }


        private void WriteContextFile()
        {
            using (BeginFile("SyncDbContext.Generated.cs"))
            {
                W("// ReSharper disable RedundantUsingDirective");
                W("// ReSharper disable DoNotCallOverridableMethodsInConstructor");
                W("// ReSharper disable InconsistentNaming");
                W("// ReSharper disable PartialTypeWithSinglePart");
                W("// ReSharper disable PartialMethodWithSinglePart");
                W("// ReSharper disable RedundantNameQualifier");
                W("// TargetFrameworkVersion = 4.51");
                W("#pragma warning disable 1591    //  Ignore \"Missing XML Comment\" warning");
                W();
                W("using System;");
                W("using System.CodeDom.Compiler;");
                W("using System.Collections.Generic;");
                W("using System.Configuration;");
                W("using Microsoft.EntityFrameworkCore;");
                W("using Microsoft.EntityFrameworkCore.Metadata;");
                W("using Microsoft.EntityFrameworkCore.Infrastructure;");
                W("using Microsoft.EntityFrameworkCore.Infrastructure.Internal;");
                W("using Mira.Web.DataAccess.Sync;");
                W("using Newtonsoft.Json;");
                W();
                W("namespace Mira.Web.DataAccess.SyncContext");
                WI("{");
                {
                    W($"[GeneratedCode(\"Geco Code Generator\", \"{Assembly.GetEntryAssembly().GetName().Version}\")]");
                    W("public partial class SyncDbContext : DbContext");
                    WI("{");
                    {
                        W("protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
                        WI("{");
                        WI("if (optionsBuilder.IsConfigured)");
                        {
                            W("return;");
                        }
                        DW();
                        W("optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings[\"MiraDb\"].ConnectionString, opt =>");
                        WI("{");
                        {
                            W("//opt.EnableRetryOnFailure();");
                        }
                        DW("});");
                        W();

                        W("optionsBuilder.ConfigureWarnings(w =>");
                        WI("{");
                        {
                            W("w.Ignore(RelationalEventId.AmbientTransactionWarning);");
                            W("w.Ignore(RelationalEventId.QueryClientEvaluationWarning);");
                        }
                        DW("});");

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
                DW("}");
            }
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

        private void WriteEntities()
        {
            foreach (var table in Db.Schemas.SelectMany<Schema, Table>(s => s.Tables).OrderBy(t => t.Name))
            {
                var existingNames = new HashSet<string>();
                var className = Inf.Pascalise(Inf.Singularise(table.Name));
                var classInterfaces = "";
                int i = 1;
                existingNames.Add(className);
                table.Metadata["Class"] = className;

                W($"[GeneratedCode(\"Geco Code Generator\", \"{Assembly.GetEntryAssembly().GetName().Version}\")]");
                W($"public partial class {className}{(!String.IsNullOrWhiteSpace(classInterfaces) ? ": " + classInterfaces : "")}");
                WI("{");
                {
                    var keyProperties = table.Columns.Where<Column>(c => c.IsKey);
                    if (keyProperties.Any())
                    {
                        W("// Key Properties");
                        foreach (var column in keyProperties)
                        {
                            var propertyName = Inf.Pascalise(column.Name);
                            CheckClash(ref propertyName, existingNames, ref i);
                            column.Metadata["Property"] = propertyName;
                            W($"public {GetClrTypeName(column.DataType)}{GetNullable(column)} {propertyName} {{get; set;}}");
                        }
                        W();
                    }


                    var scalarProperties = table.Columns.Where<Column>(c => !c.IsKey);
                    if (scalarProperties.Any())
                    {
                        W("// Scalar Properties");
                        foreach (var column in scalarProperties)
                        {
                            var propertyName = Inf.Pascalise(column.Name);
                            CheckClash(ref propertyName, existingNames, ref i);
                            column.Metadata["Property"] = propertyName;
                            W($"public {GetClrTypeName(column.DataType)}{GetNullable(column)} {propertyName} {{get; set;}}");
                        }
                        W();
                    }

                    var foreignKeyProperties = table.Columns.Where<Column>(c => c.ForeignKey != null);
                    if (foreignKeyProperties.Any())
                    {
                        W("// Foreign keys");
                        foreach (var column in foreignKeyProperties.OrderBy(c => c.Name))
                        {
                            var targetClassName = Inf.Pascalise(Inf.Singularise(column.ForeignKey.TargetTable.Name));
                            var propertyName = Inf.Pascalise(Inf.Singularise(RemoveSuffix(column.Name)));
                            CheckClash(ref propertyName, existingNames, ref i);
                            column.Metadata["NavProperty"] = propertyName;
                            W("[JsonIgnore]");
                            W($"public {targetClassName} {propertyName} {{get; set;}}");
                        }
                        W();
                    }

                    if (table.IncomingForeignKeys.Any<ForeignKey>())
                    {
                        W("// Reverse navigation");
                        foreach (var fk in table.IncomingForeignKeys.OrderBy<ForeignKey, string>(t => t.ParentTable.Name).ThenBy(t => t.FromColumn.Name))
                        {
                            var targetClassName = Inf.Pascalise(Inf.Singularise(fk.ParentTable.Name));
                            string propertyName;
                            if (table.IncomingForeignKeys.Count<ForeignKey>(f => f.ParentTable == fk.ParentTable) > 1)
                                propertyName = Inf.Pluralise(targetClassName) + Inf.Singularise(RemoveSuffix(fk.FromColumn.Name));
                            else
                                propertyName = Inf.Pluralise(targetClassName);

                            if (CheckClash(ref propertyName, existingNames, ref i))
                            {
                                propertyName = Inf.Pascalise(Inf.Pluralise(fk.ParentTable.Name) + Inf.Singularise(RemoveSuffix(fk.FromColumn.Name)));
                                CheckClash(ref propertyName, existingNames, ref i);
                            }
                            fk.Metadata["Property"] = propertyName;
                            fk.Metadata["Type"] = targetClassName;
                            W("[JsonIgnore]");
                            W($"public List<{targetClassName}> {propertyName} {{get; set;}}");
                        }
                        W();

                        W($"public {className}()");
                        WI("{");
                        {
                            foreach (var fk in table.IncomingForeignKeys.OrderBy<ForeignKey, string>(t => t.ParentTable.Name).ThenBy(t => t.FromColumn.Name))
                            {
                                W($"this.{fk.Metadata["Property"]} = new List<{fk.Metadata["Type"]}>();");
                            }
                        }
                        DW("}");
                    }

                }
                DW("}");
                W();
            }
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
                        W($"entity.HasKey(e => e.{col.Name})");
                        SemiColon();
                    }
                    else if (table.Columns.Count<Column>(c => c.IsKey) > 1)
                    {
                        W($"entity.HasKey(e => new {{ {string.Join(", ", table.Columns.Where<Column>(c => c.IsKey).Select(c => "e." + c.Name))} }});");
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

                    foreach (var column in table.Columns.Where<Column>(c => c.ForeignKey != null))
                    {
                        var propertyName = column.Metadata["NavProperty"];
                        var reverse = column.ForeignKey.Metadata["Property"];
                        DW($"entity.HasOne(e => e.{propertyName})");
                        IW($".WithMany(p => p.{reverse})");
                        W($".HasForeignKey(p => p.{column.ForeignKey.FromColumn.Name})");
                        W($".OnDelete(DeleteBehavior.Restrict)"); // TODO: Get actual behavior for constraint from database
                        W($".HasConstraintName(\"{column.ForeignKey.Name}\")");
                        SemiColon();
                        W();
                    }
                    Dedent();
                }
                DW("});");
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

        private readonly HashSet<string> stringTypes = new HashSet<string>() { "nvarchar", "varchar", "char" };
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
            if (column.IsNullable && Db.TypeMappings[column.DataType].GetTypeInfo().IsPrimitive)
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
                sysType = GetCharpTypeName(Db.TypeMappings[sqlType]);
            }
            return sysType;
        }

        private string GetColumnType(Column column)
        {
            if (IsString(column.DataType))
            {
                return $"{column.DataType}({(column.MaxLength == -1 || column.MaxLength >= 8000 ? "MAX" : (column.MaxLength / 2).ToString())})";
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


    public class EfCoreModelGeneratorOptions
    {
        public string OutputPath { get; set; }
    }
}