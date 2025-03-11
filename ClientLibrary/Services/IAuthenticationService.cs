using ClientLibrary.Models;
using ClientLibrary.Models.Authentication;

namespace ClientLibrary.Services
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse> CreateUser(CreateUser user);
        Task<LoginResponse> Login(LoginUser user);
        Task<LoginResponse> RefreshToken(string token);
    }
}
