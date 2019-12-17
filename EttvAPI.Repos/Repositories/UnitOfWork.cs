using System.Threading.Tasks;
using EttvAPI.Data.Models;
using EttvAPI.Repos.Interfaces.Repositories;

namespace EttvAPI.Repos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EttvDbContext _dbContext;
        public AppUserRepository appUserRepository { get; private set; }
        public VideoContentRepository videoContentRepository { get; private set; }
        public ChannelProgramRepository channelProgramRepository { get; private set; }
        public UnitOfWork(EttvDbContext context)
        {
            _dbContext = context;
            appUserRepository = new AppUserRepository(this._dbContext);
            videoContentRepository = new VideoContentRepository(this._dbContext);
            channelProgramRepository = new ChannelProgramRepository(this._dbContext);
        }
        //public void Dispose()
        //{
        //    _dbContext.Dispose();
        //}

        public async Task Commit()
        {
          await _dbContext.SaveChangesAsync();
        }
    }
}
