using System.Collections.Generic;
using System.Linq;
using ECommerce_Shop_Online_MVC_Data.Infrastructure;
using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Service.Implementation;
using ECommerce_Shop_Online_MVC_Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace ECommerce_Shop_Online_MVC_UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IRepository<PostCategory, int>> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IRepository<PostCategory, int>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() {Id =1 ,Name="DM1",Status=Status.Active },
                new PostCategory() {Id =2 ,Name="DM2",Status=Status.Active },
                new PostCategory() {Id =3 ,Name="DM3",Status=Status.Active },
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory.AsQueryable());

            //call action
            var result = _categoryService.GetAll().ToList();

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory();
            int id = 1;
            category.Name = "Test";
            category.Alias = "test";
            category.Status = Status.Active;

            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
              {
                  p.Id = 1;
                  return p;
              });

            var result = _categoryService.Add(category);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);


        }
    }
}
