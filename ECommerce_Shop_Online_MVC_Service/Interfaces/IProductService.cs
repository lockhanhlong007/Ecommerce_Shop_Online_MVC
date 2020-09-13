using System.Collections.Generic;
using System.Linq;
using ECommerce_Shop_Online_MVC_Model.Models;

namespace ECommerce_Shop_Online_MVC_Service.Interfaces
{
    public interface IProductService
    {
        Product Add(Product Product);

        void Update(Product Product);

        Product Delete(int id);

        IQueryable<Product> GetAll();

        IQueryable<Product> GetAll(string keyword);

        Product GetById(int id);

        void Save();
    }
}