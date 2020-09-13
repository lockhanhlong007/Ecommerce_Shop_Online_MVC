using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using System;
using System.Collections.Generic;

namespace ECommerce_Shop_Online_MVC_Web.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public int CategoryId { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }
        public bool? HotFlag { set; get; }

        public int ViewCount { get; set; }

        public virtual PostCategoryViewModel PostCategory { set; get; }

        public IEnumerable<PostTagViewModel> PostTags { set; get; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public Status Status { get; set; }
    }
}