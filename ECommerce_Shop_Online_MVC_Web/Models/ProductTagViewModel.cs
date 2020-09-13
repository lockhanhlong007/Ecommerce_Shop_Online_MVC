namespace ECommerce_Shop_Online_MVC_Web.Models
{
    public class ProductTagViewModel
    {
        public int ProductId { get; set; }

        public string TagId { get; set; }

        public virtual TagViewModel Tag { set; get; }

        public virtual ProductViewModel Product { set; get; }
    }
}