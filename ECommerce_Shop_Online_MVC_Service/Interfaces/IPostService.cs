using System.Collections.Generic;
using System.Linq;
using ECommerce_Shop_Online_MVC_Model.Models;

namespace ECommerce_Shop_Online_MVC_Service.Interfaces
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int id);

        IQueryable<Post> GetAll();

        IQueryable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        IQueryable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

        Post GetById(int id);

        IQueryable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
}