using System.Collections.Generic;

namespace ECommerce_Shop_Online_MVC_Web.Models
{
    public class TagViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public virtual IEnumerable<ProductTagViewModel> ProductTags { set; get; }

        public virtual IEnumerable<PostTagViewModel> ProPostTags { set; get; }
    }
}