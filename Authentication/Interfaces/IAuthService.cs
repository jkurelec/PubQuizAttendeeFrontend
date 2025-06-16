using PubQuizAttendeeFrontend.Models.Auth;

namespace PubQuizAttendeeFrontend.Authentication.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginUserDto loginDto);
        Task LogoutAsync();
        Task<bool> TryRefreshTokenAsync();
        Task<bool> RegisterAsync(RegisterUserDto registerDto);
    }
}
