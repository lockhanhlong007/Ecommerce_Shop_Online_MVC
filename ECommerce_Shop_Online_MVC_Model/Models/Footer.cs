using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Shop_Online_MVC_Model.Models
{
    [Table("Footers")]
    public class Footer
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}