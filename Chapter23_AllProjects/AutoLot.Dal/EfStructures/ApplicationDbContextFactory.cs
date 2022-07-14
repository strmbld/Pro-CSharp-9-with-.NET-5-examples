using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using AutoLot.Dal.EfStructures;

namespace AutoLot.Dal.EfStructures
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
            string connectionString = @"server=.,5433;Database=AutoLot;User Id=sa;Password=P@ssw0rd;";
            optionsBuilder.UseSqlServer(connectionString);
            Console.WriteLine($"Connecting to: {connectionString}");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
