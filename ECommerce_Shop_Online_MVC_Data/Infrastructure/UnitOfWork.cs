namespace ECommerce_Shop_Online_MVC_Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;

        private ECommerceShopDbContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public ECommerceShopDbContext DbContext => _dbContext ??= _dbFactory.Init();

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}