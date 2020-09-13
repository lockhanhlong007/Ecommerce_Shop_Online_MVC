using System.Collections.Generic;
using System.Linq;
using ECommerce_Shop_Online_MVC_Common;
using ECommerce_Shop_Online_MVC_Data.Infrastructure;
using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Service.Interfaces;

namespace ECommerce_Shop_Online_MVC_Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IRepository<ProductTag, int> _productTagRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product, int> productRepository, IRepository<ProductTag, int> productTagRepository, IUnitOfWork unitOfWork, IRepository<Tag, string> tagRepository)
        {
            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
            _tagRepository = tagRepository;
        }

        public IQueryable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product Add(Product product)
        {
            var _product = _productRepository.Add(product);
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.Id == tagId) == 0)
                    {
                        Tag tag = new Tag {Id = tagId, Name = tags[i], Type = CommonConstants.ProductTag};
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag {ProductId = product.Id, TagId = tagId};
                    _productTagRepository.Add(productTag);
                }
            }
            _unitOfWork.Commit();
            return _product;
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IQueryable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.Id == tagId) == 0)
                    {
                        Tag tag = new Tag {Id = tagId, Name = tags[i], Type = CommonConstants.ProductTag};
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.DeleteMulti(x => x.ProductId == product.Id);
                    var productTag = new ProductTag {ProductId = product.Id, TagId = tagId};
                    _productTagRepository.Add(productTag);
                }

            }
        }
    }
}