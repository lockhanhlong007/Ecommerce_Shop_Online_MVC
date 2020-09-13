using System.Collections.Generic;
using System.Linq;
using ECommerce_Shop_Online_MVC_Data.Infrastructure;
using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Service.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace ECommerce_Shop_Online_MVC_Service.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory, int> _productCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IRepository<ProductCategory, int> productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            return _productCategoryRepository.Add(productCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IQueryable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IQueryable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _productCategoryRepository.GetAll();

        }

        public IQueryable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status == Status.Active && x.ParentId == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory productCategory)
        {
            _productCategoryRepository.Update(productCategory);
        }
    }
}