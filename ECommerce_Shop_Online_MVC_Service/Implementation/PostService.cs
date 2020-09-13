using System.Collections.Generic;
using System.Linq;
using ECommerce_Shop_Online_MVC_Data.Infrastructure;
using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Service.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace ECommerce_Shop_Online_MVC_Service.Implementation
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post, int> _postRepository;
        private readonly IRepository<PostTag, int> _postTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IRepository<Post, int> postRepository, IUnitOfWork unitOfWork, IRepository<PostTag, int> postTagRepository)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
            _postTagRepository = postTagRepository;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IQueryable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IQueryable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status == Status.Active && x.CategoryId == categoryId, out totalRow, page, pageSize, new string[] { "PostCategory" });
        }

        public IQueryable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            var query = _postRepository.GetAll().Join(_postTagRepository.GetAll(), p => p.Id, pt => pt.PostId, (p, pt) => new { p, pt })
                .Where(z => z.pt.TagId.Equals(tag) && z.p.Status == Status.Active)
                .OrderByDescending(z => z.p.DateCreated).Select(z => z.p);

            var enumerable = query.ToList();
            totalRow = enumerable.Count();
            query = (IQueryable<Post>)enumerable.Skip((page - 1) * pageSize).Take(pageSize);
            return query;
        }

        public IQueryable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status == Status.Active, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}