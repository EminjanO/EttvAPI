using System.Collections.Generic;
using EttvAPI.Data.Models;
using EttvAPI.Services.Communication;

namespace EttvAPI.Services.Interfaces
{
    public interface IAppUserService
    {
        IEnumerable<AppUser> List();
        AppUserResponce Save(AppUser appUser);
        AppUserResponce Update(int id, AppUser appUser);
        AppUserResponce Delete(int id);
    }
}
