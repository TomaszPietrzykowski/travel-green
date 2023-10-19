using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelGreen.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
