using TravelGreen.Data;

namespace TravelGreen.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
