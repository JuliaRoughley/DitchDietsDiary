using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DitchDietsDiary.Core;
using Microsoft.EntityFrameworkCore;

namespace DitchDietsDiary.Infrastructure.Data
{
    public class FoodLoggingDbContext : DbContext
    {
        // Constructor for dependency injection
        public FoodLoggingDbContext(DbContextOptions<FoodLoggingDbContext> options)
            : base(options)
        {
        }

        // DbSet for FoodEntryModel, which represents a table in the database
        public DbSet<FoodEntryModel> FoodEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly configure the primary key
            modelBuilder.Entity<FoodEntryModel>()
                .HasKey(fe => fe.FoodEntryId);
        }
    }
}
