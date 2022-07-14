using System.IO;
using AutoLot.Dal.EfStructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace AutoLot.Dal.Tests
{
    public static class TestHelper
    {
        public static IConfiguration GetConfiguration()
            => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        public static ApplicationDbContext GetContext(IConfiguration configuration)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
            string connectionString = configuration.GetConnectionString("AutoLot");
            optionsBuilder.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure());

            return new(optionsBuilder.Options);
        }

        public static ApplicationDbContext GetContextFromExisting(ApplicationDbContext oldContext, IDbContextTransaction transaction)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(oldContext.Database.GetDbConnection(), sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            ApplicationDbContext context = new(optionsBuilder.Options);
            context.Database.UseTransaction(transaction.GetDbTransaction());

            return context;
        }
    }
}
