using FridgeSensorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FridgeSensorAPI.Contexts
{
    public class SensorContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        public SensorContext(DbContextOptions<SensorContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().ToTable("Records").HasKey("TimeStamp");
            base.OnModelCreating(modelBuilder);
        }
    }
}
