using EttvAPI.Data.Models;

namespace EttvAPI.Repos.Interfaces.Repositories
{
    public interface IVideoContentRepository
    {
        VideoContent GetByStringId(string videoId);
    }
}
