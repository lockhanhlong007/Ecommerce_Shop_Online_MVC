using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce_Shop_Online_MVC_Model.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace ECommerce_Shop_Online_MVC_Model.Models
{
    [Table("Slides")]
    public class Slide : ISwitchable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [MaxLength(256)]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        public Status Status { get; set; }
    }
}