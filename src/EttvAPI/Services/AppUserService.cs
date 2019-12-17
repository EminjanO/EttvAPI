using System;
using System.Collections.Generic;
using System.Linq;
using EttvAPI.Data.Models;
using EttvAPI.Repos.Interfaces.Repositories;
using EttvAPI.Repos.Repositories;
using EttvAPI.Services.Communication;
using EttvAPI.Services.Interfaces;

namespace EttvAPI.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UnitOfWork _unitOfWork;

        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        public IEnumerable<AppUser> List()
        {
            return _unitOfWork.appUserRepository.GetAll();
        }

        public AppUserResponce Save(AppUser appUser)
        {
            try
            {
                _unitOfWork.appUserRepository.AddUser(appUser.LastName, appUser.FirstName, appUser.Email, appUser.HashPassword, appUser.ProfileId);
                _unitOfWork.Commit();

                return new AppUserResponce(appUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new AppUserResponce($"An error occurred when saving the user: {ex.Message}");
            }
        }

        public AppUserResponce Update(int id, AppUser appUser)
        {
            var existingUser = _unitOfWork.appUserRepository.GetById(id);

            if (existingUser == null)
                return new AppUserResponce("User not found.");

            existingUser.ProfileId = appUser.ProfileId;

            try
            {
                _unitOfWork.appUserRepository.Update(existingUser);
                _unitOfWork.Commit();

                return new AppUserResponce(existingUser);
            }
            catch (Exception ex)
            {
                //TODO some logging stuff here
                return new AppUserResponce($"An error occurred when updating the Programs Scheduling Time: {ex.Message}");
            }
        }

        public AppUserResponce Delete(int id)
        {
            var existingUser = _unitOfWork.appUserRepository.GetById(id);

            if (existingUser == null)
                return new AppUserResponce("User not found.");

            try
            {
                _unitOfWork.appUserRepository.Delete(existingUser);
                _unitOfWork.Commit();

                return new AppUserResponce(existingUser);
            }
            catch (Exception ex)
            {
                //TODO some logging stuff here
                return new AppUserResponce($"An error occurred when deleting the user : {ex.Message}");
            }

        }
    }
}
