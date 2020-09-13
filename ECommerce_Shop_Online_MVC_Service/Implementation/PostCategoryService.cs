using System.Collections.Generic;
using System.Linq;
using ECommerce_Shop_Online_MVC_Data.Infrastructure;
using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Service.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace ECommerce_Shop_Online_MVC_Service.Implementation
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IRepository<PostCategory, int> _postCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostCategoryService(IRepository<PostCategory, int> postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
           return _postCategoryRepository.Delete(id);
        }

        public IQueryable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IQueryable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status == Status.Active && x.ParentId == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}