using System;
using System.Threading.Tasks;

namespace EttvAPI.Repos.Interfaces.Repositories
{
    public interface IUnitOfWork// : IDisposable
    {
        Task Commit();
    }
}
