using Microsoft.EntityFrameworkCore;

namespace BananaStore.Models
{
    public class BananaStoreDbContext : DbContext
    {
        public BananaStoreDbContext(DbContextOptions<BananaStoreDbContext> options)
            : base(options)
        {
        }
        public BananaStoreDbContext()
        {
        }
        public DbSet<Banana> Bananas { get; set; }
        public DbSet<Box> Boxes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Box>()
                .HasMany(b => b.Bananas)
                .WithOne()
                .HasForeignKey(b => b.Box_ID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
