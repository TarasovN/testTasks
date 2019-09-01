using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OzonTest.Migrations.Migrations;
using System;
using System.IO;

namespace OzonTest.Migrations
{
    class Program
    {      

        static void Main(string[] args)
        {            
            var configuration = GetConfiguration();

            var baseConnectionStr = configuration.GetConnectionString("postgres");
            var connectionString = configuration.GetConnectionString("ozon");

            var serviceProvider = CreateServices(connectionString);
            
            if(!DbUtilities.DBExists(baseConnectionStr, "ozon"))
            {
                DbUtilities.CreateDB(baseConnectionStr, "ozon");
            }

            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            Console.WriteLine("Filling test data");

            if (!DbUtilities.FillTestData(connectionString))
            {
                Console.WriteLine("Test data was not added");
            }
        }
                
        private static IServiceProvider CreateServices(string connectionStr)
        {
            return new ServiceCollection()                
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb                    
                    .AddPostgres()                    
                    .WithGlobalConnectionString(connectionStr)                    
                    .ScanIn(typeof(AddPhrases).Assembly).For.Migrations())                
                .AddLogging(lb => lb.AddFluentMigratorConsole())                
                .BuildServiceProvider(false);
        }

        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

            return builder.Build();
        }
                
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {            
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                        
            runner.MigrateUp();
        }
    }
}
