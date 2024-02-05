using Backend.DTOs.Auth;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services
{
    public interface IAuthService
    {
        Task<IEnumerable<IdentityError>> RegisterUser(RegisterUserDto registerUserDto);
        Task<bool> LoginUser(LoginUserDto loginUserDto);
    }
}
