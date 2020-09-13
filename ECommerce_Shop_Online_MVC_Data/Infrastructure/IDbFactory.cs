using System;

namespace ECommerce_Shop_Online_MVC_Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ECommerceShopDbContext Init();
    }
}