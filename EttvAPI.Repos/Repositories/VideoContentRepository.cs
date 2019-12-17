using System.Collections.Generic;
using System.Linq;
using EttvAPI.Data.Models;
using EttvAPI.Repos.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EttvAPI.Repos.Repositories
{
    public class VideoContentRepository : GenericRepository<VideoContent>, IVideoContentRepository
    {
        private readonly EttvDbContext _dbContext;
        public VideoContentRepository(EttvDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<VideoContent> GetAll()
        {
            return _dbContext.VideoContents.Include(p => p.AppUser).ToList();
        }

        public VideoContent GetByStringId(string videoId)
        {
            return _dbContext.VideoContents.Find(videoId);
        }

        public override void Delete(VideoContent entity)
        {
            base.Delete(entity);
        }
    }
}
