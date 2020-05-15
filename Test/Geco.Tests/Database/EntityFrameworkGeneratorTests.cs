using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Geco.Tests.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Geco.Tests.Database
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


        [Fact]
        public void QueryAllTables()
        {
            var ctx = new AdventureWorksContext(configuration);
            var dbSets = ctx.GetType().GetTypeInfo()
                .DeclaredProperties
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p);

            var mi = this.GetType().GetMethod(nameof(Query), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var dbSet in dbSets)
            {
                var genericMethod = mi.MakeGenericMethod(dbSet.PropertyType.GetGenericArguments()[0]);
                genericMethod.Invoke(this, new []{dbSet.GetMethod.Invoke(ctx, null)});
            } 
        }

        private void Query<T>(DbSet<T> dbSet)
            where T:class
        {
            var result = dbSet.FirstOrDefault();
        }
    }
}
