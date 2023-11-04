using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelGreen.Contracts;
using TravelGreen.Data;

namespace TravelGreen.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly TravelGreenDbContext _context;
        public CountriesRepository(TravelGreenDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
        }

        public TravelGreenDbContext Context { get; }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
