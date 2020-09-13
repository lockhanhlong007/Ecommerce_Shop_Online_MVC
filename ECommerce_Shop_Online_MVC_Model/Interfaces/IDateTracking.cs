using System;

namespace ECommerce_Shop_Online_MVC_Model.Interfaces
{
    public interface IDateTracking
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}