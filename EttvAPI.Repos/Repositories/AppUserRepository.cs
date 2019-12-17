using System.Collections.Generic;
using System.Linq;
using EttvAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using EttvAPI.Repos.Interfaces.Repositories;

namespace EttvAPI.Repos.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly EttvDbContext _dbContext;
        public AppUserRepository(EttvDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<AppUser> GetAll()
        {
            return _dbContext.AppUsers.Include(p => p.Profile).ToList();
        }

        public int AddUser(string lastName, string firstName, string email, string password, int profileId)
        {
            //return _dbContext.Database.ExecuteSqlCommand("AddUser @LastName = {0} @FirstName = {1} @Email = {2} @Passwd = {3} @ProfileId = {4}",
            return _dbContext.Database.ExecuteSqlCommand("AddUser @p0, @p1, @p2, @p3, @p4",
                parameters: new List<object> {lastName,firstName,email, password, profileId });
        }

        public AppUser CheckUser(string email, string password)
        {
           //var result = _dbContext.Database.ExecuteSqlCommand("CheckUser @Email = {0}, @Passwd = {1}", email, password);
           var result = _dbContext.AppUsers.FromSql("CheckUser @Email = {0}, @Passwd = {1}", email, password);
           //return _dbContext.AppUsers.Find(email);
            //AppUser user = (from x in _dbContext.AppUsers.Where(x => x.Email == email) select x).FirstOrDefault();
            if(result.Any())
                return GetAll().Where(x => x.Email == email).SingleOrDefault();
            return default(AppUser);
        }
    }
}
 