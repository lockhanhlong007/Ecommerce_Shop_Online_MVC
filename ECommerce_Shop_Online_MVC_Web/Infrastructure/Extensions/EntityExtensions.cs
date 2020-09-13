using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Web.Models;

namespace ECommerce_Shop_Online_MVC_Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVewModel)
        {
            postCategory.Id = postCategoryVewModel.Id;
            postCategory.Name = postCategoryVewModel.Name;
            postCategory.Alias = postCategoryVewModel.Alias;
            postCategory.ParentId = postCategoryVewModel.ParentId;
            postCategory.DisplayOrder = postCategoryVewModel.DisplayOrder;
            postCategory.Image = postCategoryVewModel.Image;
            postCategory.HomeFlag = postCategoryVewModel.HomeFlag;

            postCategory.DateCreated = postCategoryVewModel.DateCreated;
            postCategory.DateModified = postCategoryVewModel.DateModified;
            postCategory.SeoAlias = postCategoryVewModel.SeoAlias;
            postCategory.SeoPageTitle = postCategoryVewModel.SeoPageTitle;
            postCategory.SeoKeywords = postCategoryVewModel.SeoKeywords;
            postCategory.SeoDescription = postCategoryVewModel.SeoDescription;
            postCategory.Status = postCategoryVewModel.Status;

        }
        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVewModel)
        {
            productCategory.Id = productCategoryVewModel.Id;
            productCategory.Name = productCategoryVewModel.Name;
            productCategory.Alias = productCategoryVewModel.Alias;
            productCategory.ParentId = productCategoryVewModel.ParentId;
            productCategory.DisplayOrder = productCategoryVewModel.DisplayOrder;
            productCategory.Image = productCategoryVewModel.Image;
            productCategory.HomeFlag = productCategoryVewModel.HomeFlag;

            productCategory.DateCreated = productCategoryVewModel.DateCreated;
            productCategory.DateModified = productCategoryVewModel.DateModified;
            productCategory.SeoAlias = productCategoryVewModel.SeoAlias;
            productCategory.SeoPageTitle = productCategoryVewModel.SeoPageTitle;
            productCategory.SeoKeywords = productCategoryVewModel.SeoKeywords;
            productCategory.SeoDescription = productCategoryVewModel.SeoDescription;
            productCategory.Status = productCategoryVewModel.Status;

        }
        public static void UpdatePost(this Post post, PostViewModel postVewModel)
        {
            post.Id = postVewModel.Id;
            post.Name = postVewModel.Name;
            post.Description = postVewModel.Description;
            post.Alias = postVewModel.Alias;
            post.CategoryId = postVewModel.CategoryId;
            post.Content = postVewModel.Content;
            post.Image = postVewModel.Image;
            post.HomeFlag = postVewModel.HomeFlag;
            post.ViewCount = postVewModel.ViewCount;

            post.DateCreated = postVewModel.DateCreated;
            post.DateModified = postVewModel.DateModified;
            post.SeoKeywords = postVewModel.SeoKeywords;
            post.SeoDescription = postVewModel.SeoDescription;
            post.SeoAlias = postVewModel.SeoAlias;
            post.SeoPageTitle = postVewModel.SeoPageTitle;
            post.Status = postVewModel.Status;
        }

        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.Id = productViewModel.Id;
            product.Name = productViewModel.Name;
            product.Description = productViewModel.Description;
            product.Alias = productViewModel.Alias;
            product.CategoryId = productViewModel.CategoryId;
            product.Content = productViewModel.Content;
            product.Image = productViewModel.Image;
            product.MoreImages = productViewModel.MoreImages;
            product.Price = productViewModel.Price;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Warranty = productViewModel.Warranty;
            product.HomeFlag = productViewModel.HomeFlag;
            product.ViewCount = productViewModel.ViewCount;

            product.DateCreated = productViewModel.DateCreated;
            product.DateModified = productViewModel.DateModified;
            product.SeoKeywords = productViewModel.SeoKeywords;
            product.SeoDescription = productViewModel.SeoDescription;
            product.SeoAlias = productViewModel.SeoAlias;
            product.SeoPageTitle = productViewModel.SeoPageTitle;
            product.Status = productViewModel.Status;
            product.Tags = productViewModel.Tags;
        }
    }
}