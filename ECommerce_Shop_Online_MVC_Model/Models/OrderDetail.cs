using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Shop_Online_MVC_Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }
    }
}