using System.Collections.Generic;
using System.Linq;
using ECommerce_Shop_Online_MVC_Model.Models;

namespace ECommerce_Shop_Online_MVC_Service.Interfaces
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory ProductCategory);

        void Update(ProductCategory ProductCategory);

        ProductCategory Delete(int id);

        IQueryable<ProductCategory> GetAll();

        IQueryable<ProductCategory> GetAll(string keyword);

        IQueryable<ProductCategory> GetAllByParentId(int parentId);

        ProductCategory GetById(int id);

        void Save();
    }
}