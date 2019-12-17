using System;
using System.Linq;
using EttvAPI.Controllers;
using EttvAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EttvAPI.Tests
{
    public class AppUserQueriesTest
    {
        ValuesController controller = new ValuesController();
        [Fact]
        public void GetReturnsCorrectNumber()
        {
            var returnValue = controller.Get(1);
            Assert.Equal("EminjanO", returnValue.Value);
        }

        [Fact]
        public void ShouldBeReturnAllAppUsers()
        {
            var options = new DbContextOptionsBuilder<EttvDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new EttvDbContext(options);

            Seed(context);
            
            var query = context.AppUsers
                .OrderBy(a => a.Id)
                .ToList();
            
            Assert.Equal(3, query.Count);
        }

        [Fact]
        public void ShouldBOrderAppUsersByFirstName()
        {
            var options = new DbContextOptionsBuilder<EttvDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new EttvDbContext(options);

            Seed(context);

            var query = context.AppUsers
                .OrderBy(a => a.FirstName)
                .ToList();

            Assert.Equal("aa", query.First().FirstName);
            Assert.Equal("cc", query.Last().FirstName);
        }

        private void Seed(EttvDbContext context)
        {
            var appUser = new[]
            {
                new AppUser()
                {
                    Id = 1, Email = "aa@aa.aa", FirstName = "aa", LastName = "aaLast", HashPassword = "aaPassword",
                    Profile = null
                },
                new AppUser
                {
                    Id = 2, Email = "bb@bb.bb", FirstName = "bb", LastName = "bbLast", HashPassword = "bbPassword",
                    Profile = null
                },
                new AppUser
                {
                    Id = 3, Email = "cc@cc.cc", FirstName = "cc", LastName = "ccLast", HashPassword = "ccPassword",
                    Profile = null
                }
            };

            context.AppUsers.AddRange(appUser);
            context.SaveChanges();
        }
    }
}
