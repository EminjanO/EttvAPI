using EttvAPI.Data.Models;
using EttvAPI.Models;
using System.Collections.Generic;

namespace EttvAPI.Services.Interfaces
{
    public interface IProfileService
    {
        IEnumerable<Profile> ListAsync();
        ProfileModel SaveAsync(Profile profile);
        ProfileModel UpdateAsync(int id, Profile profile);
        ProfileModel DeleteAsync(int id);
    }
}
