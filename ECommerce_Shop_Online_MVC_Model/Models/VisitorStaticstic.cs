using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Shop_Online_MVC_Model.Models
{
    [Table("VisitorStatistic")]
    public class VisitorStaticstic
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime VisitedDate { get; set; }

        [MaxLength(50)]
        public string IpAddress { get; set; }
    }
}