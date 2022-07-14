using Microsoft.EntityFrameworkCore;
using System;
using AutoLot.Samples.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLot.Samples
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            SavingChanges += (sender, args) => Console.WriteLine($"Saving changes for {((DbContext)sender).Database.GetConnectionString()}");

            SavedChanges += (sender, args) => Console.WriteLine($"Saved {args.EntitiesSavedCount} entities");

            SaveChangesFailed += (sender, args) => Console.WriteLine($"An exception occured! {args.Exception.Message}");
        }

        // INCLUDED TABLES
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Radio> Radios { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<BaseEntity>().ToTable("BaseEntities");
            // modelBuilder.Entity<Car>().ToTable("Cars");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Color).HasDefaultValue("Black");
                entity.Property(e => e.IsDrivable)
                .HasField("_isDrivable")
                .HasDefaultValue(true);
                
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        static void SampleSaveChanges()
        {
            var context = new ApplicationDbContextFactory().CreateDbContext(null);
            context.SaveChanges();
        }
    }
}
