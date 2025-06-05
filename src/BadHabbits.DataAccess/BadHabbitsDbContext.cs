using BadHabbits.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BadHabbits.DataAccess
{
    public class BadHabbitsDbContext : DbContext
    {
        protected BadHabbitsDbContext()
        {
        }

        public BadHabbitsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cigarette>()
                .Property(x => x.CigaretteId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cigarette>()
                .Property(x => x.Brand)
                .HasMaxLength(200);

            modelBuilder.Entity<Cigarette>()
                .Property(x => x.Name)
                .HasMaxLength(200);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cigarette> Cigarettes { get; set; }
    }
}
