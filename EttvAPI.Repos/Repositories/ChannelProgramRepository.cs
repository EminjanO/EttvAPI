using System.Collections.Generic;
using System.Linq;
using EttvAPI.Data.Models;
using EttvAPI.Repos.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EttvAPI.Repos.Repositories
{
    public class ChannelProgramRepository : GenericRepository<ChannelProgram> , IChannelProgramRepository
    {
        private readonly EttvDbContext _dbContext;
        public ChannelProgramRepository(EttvDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<ChannelProgram> GetAll()
        {
            return _dbContext.ChannelPrograms.Include(p => p.AppUser).Include(v=>v.VideoContent).ToList();
        }
    }
}
