using Microsoft.EntityFrameworkCore;

namespace pobreTITO_Models
{
    public class Queries : IStoreRepository
    {
        private PobretitoDbContext context;
        public Queries(PobretitoDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<User> Users => context.Users;
        public IQueryable<Report> Reports => context.Reports;
    }
}