using System;
using System.Collections.Generic;
using EttvAPI.Data.Models;
using EttvAPI.Models;
using EttvAPI.Services.Interfaces;

namespace EttvAPI.Services
{
    public class ProfileService : IProfileService
    {
        public IEnumerable<Profile> ListAsync()
        {
            throw new NotImplementedException();
        }

        public ProfileModel SaveAsync(Profile profile)
        {
            throw new NotImplementedException();
        }

        public ProfileModel UpdateAsync(int id, Profile profile)
        {
            throw new NotImplementedException();
        }

        public ProfileModel DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
