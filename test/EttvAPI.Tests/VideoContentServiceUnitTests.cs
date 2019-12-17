using System;
using System.Linq;
using EttvAPI.Data.Models;
using EttvAPI.Repos.Repositories;
using EttvAPI.Services;
using Microsoft.AspNetCore.Mvc.Razor.Extensions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EttvAPI.Tests
{
    public class VideoContentServiceUnitTests
    {
        [Fact]
        public void ShouldResturnVideoContents()
        {
            var options = new DbContextOptionsBuilder<EttvDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new EttvDbContext(options);

            Seed(context);

            var videocontentservice = new VideoContentService(unitOfWork: new UnitOfWork(context));

            Assert.Equal("title1", videocontentservice.List().Where(x => x.VideoId == "videoId1").SingleOrDefault().Title);
            Assert.Equal("title3", videocontentservice.List().Where(x => x.VideoId == "videoId3").LastOrDefault().Title);
        }

        [Fact]
        public void ShouldBeReturnResultsAfterAddOneVideoContent()
        {
            var options = new DbContextOptionsBuilder<EttvDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new EttvDbContext(options);

            Seed(context);

            var videocontentservice = new VideoContentService(unitOfWork: new UnitOfWork(context));

            VideoContent vc = new VideoContent
            {
                VideoId = "videoId4",
                Title = "title4",
                Thumbnail = "thumbnail4",
                Tag = "tag4",
                SrcUri = "https://www.youtube.com/watch?v=",
                SrcExtention = "youtube",
                AppUserId = 1,
                Duration = 1000
            };

            Assert.Equal(vc, videocontentservice.Save(vc).VideoContent);
            Assert.Equal(4, videocontentservice.List().Count());
        }

        [Fact]
        public void ShouldBeReturnResultsAfterUpdateOneVideoContent()
        {
            var options = new DbContextOptionsBuilder<EttvDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new EttvDbContext(options);

            Seed(context);

            var videocontentservice = new VideoContentService(unitOfWork: new UnitOfWork(context));

            VideoContent vc = new VideoContent
            {
                VideoId = "videoId3",
                Title = "title3",
                Thumbnail = "thumbnail3",
                Tag = "tag3_Updated",
                SrcUri = "https://www.youtube.com/watch?v=",
                SrcExtention = "youtube",
                AppUserId = 2,
                Duration = 3000
            };

            Assert.Equal(vc.Tag, videocontentservice.Update("videoId3",vc).VideoContent.Tag);
            Assert.Equal(vc.Title, videocontentservice.Update("videoId3",vc).VideoContent.Title);
            Assert.Equal(vc.SrcUri, videocontentservice.Update("videoId3",vc).VideoContent.SrcUri);
            Assert.Equal(vc.SrcExtention, videocontentservice.Update("videoId3",vc).VideoContent.SrcExtention);
        }

        [Fact]
        public void ShouldBeReturnResultsAfterDeleteOneVideoContent()
        {
            var options = new DbContextOptionsBuilder<EttvDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new EttvDbContext(options);

            Seed(context);

            var videocontentservice = new VideoContentService(unitOfWork: new UnitOfWork(context));

            VideoContent vc = videocontentservice.Delete("videoId1").VideoContent;

            Assert.Equal("tag1",vc.Tag);
            Assert.Equal("title1",vc.Title);
            Assert.Equal(2, videocontentservice.List().Count());
        }

        private void Seed(EttvDbContext context)
        {
            var videoContents = new[]
            {
                new VideoContent { VideoId = "videoId1", Title = "title1", Thumbnail = "thumbnail1", Tag = "tag1", AppUserId = 1, SrcUri = "https://www.youtube.com/watch?v=", SrcExtention = "youtube", Duration = 1000},
                new VideoContent { VideoId = "videoId2", Title = "title2", Thumbnail = "thumbnail2", Tag = "tag2", AppUserId = 1, SrcUri = "https://vimeo.com/", SrcExtention = "vimeo", Duration = 2000 },
                new VideoContent { VideoId = "videoId3", Title = "title3", Thumbnail = "thumbnail3", Tag = "tag3", AppUserId = 2, SrcUri = "https://www.youtube.com/watch?v=", SrcExtention = "youtube", Duration = 3000 },
            };

            var appUser = new[]
            {
                new AppUser { Id = 1, Email = "aa@aa.aa", FirstName = "aa", LastName = "aaLast", HashPassword = "aaPassword", Profile = null },
                new AppUser { Id = 2, Email = "bb@bb.bb", FirstName = "bb", LastName = "bbLast", HashPassword = "bbPassword", Profile = null },
                new AppUser { Id = 3, Email = "cc@cc.cc", FirstName = "cc", LastName = "ccLast", HashPassword = "ccPassword", Profile = null }
            };

            context.AppUsers.AddRange(appUser);
            context.VideoContents.AddRange(videoContents);
            context.SaveChanges();
        }
    }
}
