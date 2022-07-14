using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLot.Samples
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
            string connectionString = @"server=.,5433;Database=AutoLotSamples;User Id=sa;Password=P@ssw0rd;"; // Encrypt=False
            optionsBuilder.UseSqlServer(connectionString);
            Console.WriteLine(connectionString);

            return new(optionsBuilder.Options);
        }
    }
}
