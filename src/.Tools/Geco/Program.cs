using System;
using System.Diagnostics;
using System.IO;
using Geco.Common;
using Geco.Common.Metadata;
using Geco.Common.MetadataProviders;
using Geco.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Geco
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args);
            builder.Build();

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IMetadataProvider, SqlServerMetadataProvider>()
                .AddSingleton<IInflector, EnglishInflector>()
                .AddSingleton<EfCoreModelGenerator>()
                .BuildServiceProvider();

            var prov = new SqlServerMetadataProvider(@"Password=D4tab4s3User!2015;Persist Security Info=True;User ID=MiraAdmin;Initial Catalog=MiraDb;Data Source=.\SQLEXPRESS;MultipleActiveResultSets=True;Application Name=EntityFramework;MultipleActiveResultSets=True");

            var sw = new Stopwatch();
            sw.Start();
            var db = prov.LoadMetadata();
            sw.Stop();
            Console.WriteLine($"Metadata loaded in: {sw.Elapsed}");
        }
    }
}
