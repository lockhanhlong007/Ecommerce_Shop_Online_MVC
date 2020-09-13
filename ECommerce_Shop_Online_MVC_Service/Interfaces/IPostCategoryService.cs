using System.Collections.Generic;
using System.Linq;
using ECommerce_Shop_Online_MVC_Model.Models;

namespace ECommerce_Shop_Online_MVC_Service.Interfaces
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        PostCategory Delete(int id);

        IQueryable<PostCategory> GetAll();

        IQueryable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);

        void Save();
    }
}