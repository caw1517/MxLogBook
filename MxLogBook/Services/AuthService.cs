using AutoMapper;
using Backend.DTOs.Auth;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services
{
    public class AuthService : IAuthService
    {
        //Private Vars
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;   
            _userManager = userManager;
        }

        public async Task<bool> LoginUser(LoginUserDto loginUserDto)
        {
            bool isValidUser = false;

            try
            {
                //Find the user
                var user = await _userManager.FindByEmailAsync(loginUserDto.Email);

                //Check the password
                isValidUser = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);

                if(!isValidUser)
                {
                    return default;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return isValidUser;
            
        }

        public async Task<IEnumerable<IdentityError>> RegisterUser(RegisterUserDto registerUserDto)
        {
            //Map the user dto to the application user
            var user = _mapper.Map<ApplicationUser>(registerUserDto);

            //Create the user
            var result = await _userManager.CreateAsync(user, registerUserDto.Password);

            //Add user to the role - Default is User
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            //Return any errors
            return result.Errors;
        }
    }
}
