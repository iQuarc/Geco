using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Geco.Tests.Database.Model;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Geco.Tests
{
    public class EntityFrameworkGeneratorTests
    {
        private readonly IConfigurationRoot configuration;
        public EntityFrameworkGeneratorTests()
        {
            var options = new Dictionary<string, string>
            {
                {"ConnectionStrings:DefaultConnection", "Integrated Security=True; Initial Catalog=AdventureWorks; Data Source=.\\SQLEXPRESS; "}
            };
            configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(options)
                .Build();
        }

        [Fact]
        public void InstantiateContext()
        {
            var ctx = new AdventureWorksContext(configuration);
            ctx.Dispose();
        }

        [Fact]
        public void QueryForEmployeeCount()
        {
            var ctx = new AdventureWorksContext(configuration);
            var count = ctx.Employees.Count();
            Assert.True(count > 0);
        }

        [Fact]
        public void QueryForEmployees()
        {
            var ctx = new AdventureWorksContext(configuration);
            var employees = ctx.Employees.Take(10).ToList();
            Assert.True(employees.Count == 10);
        }
    }
}
