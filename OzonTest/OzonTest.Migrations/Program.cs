using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using OzonTest.Migrations.Migrations;
using System;

namespace OzonTest.Migrations
{
    class Program
    {
        private const string baseConnectionStr = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=postgres;";
        private const string connectionStr = "Server=localhost;Port=5432;Database=ozon;User Id=postgres;Password=postgres;";

        static void Main(string[] args)
        {
            var serviceProvider = CreateServices();
            
            if(!DbUtilities.DBExists(baseConnectionStr, "ozon"))
            {
                DbUtilities.CreateDB(baseConnectionStr, "ozon");
            }

            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            Console.WriteLine("Filling test data");

            if (!DbUtilities.FillTestData(connectionStr))
            {
                Console.WriteLine("Test data was not added");
            }
        }
                
        private static IServiceProvider CreateServices()
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
                
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {            
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                        
            runner.MigrateUp();
        }
    }
}
