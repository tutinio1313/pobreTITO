namespace pobreTITO_Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private PobretitoDbContext context;
        public EFStoreRepository(PobretitoDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<User> Users => context.Users;
        public IQueryable<Report> Reports => context.Reports;
    }
}