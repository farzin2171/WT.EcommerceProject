using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace WT.Ecommerce.Database.Infrastructure
{
    internal abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "DefultConnection";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        public TContext CreateDbContext(string[] args)
        {
            return Create(Directory.GetCurrentDirectory(), Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);
        private TContext Create(string basePath, string environmentName)
        {
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath + "\\..\\WT.EcommerceAdminAPI")
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();


            //ToDo:did not work with configuration
            //var connectionString = configuration[ConnectionStringName];
            var connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=WT_Ecommerce;Integrated Security=True;multipleactiveresultsets=True;App=WT_Ecommerce";

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }

    }
}
