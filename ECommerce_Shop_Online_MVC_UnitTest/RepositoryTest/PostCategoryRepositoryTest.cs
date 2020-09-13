using System.Linq;
using ECommerce_Shop_Online_MVC_Data.Infrastructure;
using ECommerce_Shop_Online_MVC_Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace ECommerce_Shop_Online_MVC_UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IDbFactory _dbFactory;
        readonly IRepository<PostCategory, int> _objRepository;
        IUnitOfWork _unitOfWork;

        public PostCategoryRepositoryTest(IRepository<PostCategory, int> objRepository)
        {
            _objRepository = objRepository;
        }

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = _objRepository.GetAll().ToList();
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = Status.Active;

            var result = _objRepository.Add(category);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Id);
        }

    }
}