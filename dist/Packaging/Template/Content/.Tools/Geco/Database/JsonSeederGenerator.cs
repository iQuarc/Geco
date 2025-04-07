using System;
using System.Collections.Generic;
using System.IO;
using Geco.Common;
using Geco.Common.Inflector;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Geco.Database
{
    [Options(typeof(JsonSeedOptions))]
    public class JsonSeederGenerator : BaseGenerator
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly JsonSeedOptions _options;

        public JsonSeederGenerator(IInflector inf, IConfigurationRoot configurationRoot, JsonSeedOptions options) : base(inf)
        {
            _configurationRoot = configurationRoot;
            _options = options;
        }

        protected override void Generate()
        {
            var connectionString = _configurationRoot.GetConnectionString(_options.ConnectionName);

            using (var reader = new StreamReader(_options.FileName))
            {
                var data = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<LookupModel>>(data);

                RunScripts(connectionString, items);
            }
        }

        private void RunScripts(string connectionString, List<LookupModel> items)
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (var tran = cnn.BeginTransaction())
                {
                    foreach (var commandText in GetCommands(items))
                    {
                        using var cmd = new SqlCommand(commandText, cnn, tran);

                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        private IEnumerable<string> GetCommands(List<LookupModel> items)
        {
            foreach (var model in items)
            {
                yield return $"INSERT INTO {_options.TableName} ({nameof(model.Code)}, {nameof(model.Name)}) VALUES ('{model.Code}', '{model.Name}')";
            }
        }
    }

    public class JsonSeedOptions
    {
        public string FileName { get; set; }

        public string TableName { get; set; }

        public string ConnectionName { get; set; }
    }

    public class LookupModel
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
