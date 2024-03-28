using Backend.DTOs.Auth;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services
{
    public interface IAuthService
    {
        Task<IEnumerable<IdentityError>> RegisterUser(RegisterUserDto registerUserDto);
        Task<AuthResponseDto> LoginUser(LoginUserDto loginUserDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
        Task<bool> UserExists(string userId);
        Task<ApplicationUser> GetUserById(string userId);
        Task<List<string>> GetUserRoles(ApplicationUser user);
        Task<bool> AddUserRole(ApplicationUser user, string roleName);
    }
}
