using Microsoft.EntityFrameworkCore;

namespace TravelGreen.Data
{
    public class TravelGreenDbContext : DbContext
    {
        public TravelGreenDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        // seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Jamaica",
                    CountryCode = "JAM"
                },
                new Country
                {
                    Id = 2,
                    Name = "Bahamas",
                    CountryCode = "BS"
                },
                new Country
                {
                    Id = 3,
                    Name = "Cayman Islands",
                    CountryCode = "CI"
                }
            );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel 
                { 
                    Id = 1,
                    Name = "Sandals R&S",
                    Address = "Negril",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Comfort Suites",
                    Address = "George Town",
                    CountryId = 3,
                    Rating = 4.3
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Grand De Moin",
                    Address = "Nassua",
                    CountryId = 2,
                    Rating = 4
                }
            );
        }
    }
}
