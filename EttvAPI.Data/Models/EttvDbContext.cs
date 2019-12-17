using Microsoft.EntityFrameworkCore;
using Humanizer;

namespace EttvAPI.Data.Models
{
    public class EttvDbContext : DbContext
    {
        public EttvDbContext(DbContextOptions<EttvDbContext> options) : base(options)
        {

        }

        public EttvDbContext(DbContextOptionsBuilder builder)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<VideoContent> VideoContents { get; set; }
        public DbSet<ChannelProgram> ChannelPrograms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ChannelProgram>()
                .Property(b => b.ModifiedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<VideoContent>()
                .HasOne(a => a.AppUser)
                .WithMany(v => v.VideoContents)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<ChannelProgram>()
            //    .HasOne(v => v.VideoContent)
            //    .WithMany(c => c.ChannelPrograms)
            //    .HasForeignKey(x=>x.VideoContentVideoId);

            // Singularize table name
            // Blogs => Blog
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Add NuGet package "Humanizer" to use Singularize()
                entityType.Relational().TableName = entityType.Relational().TableName.Singularize();
            }
            // Prefix column names with table name
            // Id => Blog_Id
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    foreach (var property in entityType.GetProperties())
            //    {
            //        property.Relational().ColumnName = entityType.Relational().TableName + "_" + property.Relational().ColumnName;
            //    }
            //}
            modelBuilder.Seed();
        }
    }
}
