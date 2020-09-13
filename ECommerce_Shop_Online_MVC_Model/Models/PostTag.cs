using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Shop_Online_MVC_Model.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(Order = 1)]
        public int PostId { get; set; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}