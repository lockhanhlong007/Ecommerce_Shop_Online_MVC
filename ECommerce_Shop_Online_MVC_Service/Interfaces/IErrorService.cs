using ECommerce_Shop_Online_MVC_Model.Models;

namespace ECommerce_Shop_Online_MVC_Service.Interfaces
{
    public interface IErrorService
    {
        Error Create(Error error);
        void Save();
    }
}