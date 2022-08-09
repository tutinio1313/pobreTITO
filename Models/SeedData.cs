using Microsoft.EntityFrameworkCore;

namespace pobreTITO_Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            PobretitoDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PobretitoDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Name = "Andrés",
                        Lastname = "Rossini",
                        Email = "tuti1313@yahoo.com",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}