using EttvAPI.Data.Models;
using EttvAPI.Models;

namespace EttvAPI.Services.Interfaces
{
    public interface ILoginService
    {
        AppUser UserLogin(LoginModel lonModel);
    }
}
