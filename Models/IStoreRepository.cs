namespace pobreTITO_Models
{
    public interface IStoreRepository
    {
        IQueryable<User> Users { get; }

        IQueryable<Report> Reports {get;}
    }
}