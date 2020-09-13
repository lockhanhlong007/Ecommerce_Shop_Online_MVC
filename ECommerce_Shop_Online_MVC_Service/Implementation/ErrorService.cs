using ECommerce_Shop_Online_MVC_Data.Infrastructure;
using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Service.Interfaces;

namespace ECommerce_Shop_Online_MVC_Service.Implementation
{
    public class ErrorService : IErrorService
    {
        private readonly IRepository<Error, int> _errorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ErrorService(IRepository<Error, int> errorRepository,IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }
        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
