using EttvAPI.Data.Models;
using EttvAPI.Models;
using EttvAPI.Repos.Interfaces.Repositories;
using EttvAPI.Repos.Repositories;
using EttvAPI.Services.Interfaces;

namespace EttvAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly UnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        public AppUser UserLogin(LoginModel lonModel)
        {

            return _unitOfWork.appUserRepository.CheckUser(lonModel.Email, lonModel.HashPassword);
        }
    }
}
