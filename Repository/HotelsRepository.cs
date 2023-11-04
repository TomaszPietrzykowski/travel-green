using AutoMapper;
using TravelGreen.Contracts;
using TravelGreen.Data;

namespace TravelGreen.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(TravelGreenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
