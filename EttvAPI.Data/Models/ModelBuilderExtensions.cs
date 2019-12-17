using Microsoft.EntityFrameworkCore;

namespace EttvAPI.Data.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
                new
                {
                    Id = 1,
                    Name = "Admin"
                },
                new
                {
                    Id = 2,
                    Name = "Volunteer"
                },
                new
                {
                    Id = 3,
                    Name = "N/A"
                }
            );
        }
    }
}
