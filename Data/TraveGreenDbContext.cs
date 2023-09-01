using Microsoft.EntityFrameworkCore;

namespace TravelGreen.Data
{
    public class TraveGreenDbContext : DbContext
    {
        public TraveGreenDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
