using EttvAPI.Data.Models;

namespace EttvAPI.Repos.Interfaces.Repositories
{
    public interface IAppUserRepository
    {
        int AddUser(string lastName, string firstName, string email, string password, int profileId);
        AppUser CheckUser(string email, string password);
    }
}
