using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace ECommerce_Shop_Online_MVC_Web.Models
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên danh mục")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề SEO")]
        public string Alias { set; get; }

        public int? ParentId { get; set; }

        public int? DisplayOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { set; get; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập trạng thái")]
        public Status Status { set; get; }
    }
}