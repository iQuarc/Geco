using Geco.Common;
using Geco.Common.MetadataProviders.SqlServer;
using Geco.Common.SimpleMetadata;
using Geco.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var rootConfig = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddCommandLine(args)
            .Build();

        var opt = new EfCoreModelGeneratorOptions()
        {
            OutputPath = "Generated/"
        };

        //setup our DI
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton(rootConfig)
            .AddSingleton(opt)
            .AddSingleton<IMetadataProvider, SqlServerMetadataProvider>()
            .AddSingleton<IInflector, EnglishInflector>()
            .AddSingleton<EfCoreModelGenerator>()
            .BuildServiceProvider();

        var sw = new Stopwatch();
        sw.Start();
        var generator = serviceProvider.GetService<EfCoreModelGenerator>();
        generator.Run();
        sw.Stop();
        Console.WriteLine($"Metadata loaded in:{sw.Elapsed}");
    }
}