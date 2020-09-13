namespace ECommerce_Shop_Online_MVC_Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ECommerceShopDbContext _dbContext;

        public ECommerceShopDbContext Init()
        {
            return _dbContext ??= new ECommerceShopDbContext();
        }

        protected override void DisposeCore()
        {
            // Cách 1: (*) C1 và C2 bằng nghĩa nhau
            //if (_dbContext != null)
            //{
            //    _dbContext.Dispose();
            //}
            // Cách 2:
            _dbContext?.Dispose();
        }
    }
}