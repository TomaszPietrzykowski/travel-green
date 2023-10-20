using Microsoft.AspNetCore.Identity;
using TravelGreen.Models.Users;

namespace TravelGreen.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<bool> Login(LoginUserDto userDto);
    }
}
