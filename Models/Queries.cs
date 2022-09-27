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
        public bool DNIExistsAlredy(string id) => context.Users.Where(x=> x.DNI == id) == null;
    }
}