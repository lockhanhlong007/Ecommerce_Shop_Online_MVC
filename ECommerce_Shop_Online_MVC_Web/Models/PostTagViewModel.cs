namespace ECommerce_Shop_Online_MVC_Web.Models
{
    public class PostTagViewModel
    {
        public int PostId { get; set; }

        public string TagId { get; set; }

        public virtual PostViewModel Post { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}