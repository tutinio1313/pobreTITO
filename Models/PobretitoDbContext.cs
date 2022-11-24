using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace pobreTITO_Models
{
    public class PobretitoDbContext : IdentityDbContext<User>
    {
        public PobretitoDbContext(DbContextOptions<PobretitoDbContext> options) : base(options) { }
        
        public DbSet<User> Users => Set<User>();
        public DbSet<Report> Reports => Set<Report>();
        
    }
}