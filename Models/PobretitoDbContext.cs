using Microsoft.EntityFrameworkCore;
namespace pobreTITO_Models
{
    public class PobretitoDbContext : DbContext
    {
        public PobretitoDbContext(DbContextOptions<PobretitoDbContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Report> Reports => Set<Report>();
    }
}