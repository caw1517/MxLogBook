using AutoMapper;
using Backend.DTOs.Auth;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Services
{
    public class AuthService : IAuthService
    {
        //Private Vars
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;   
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> LoginUser(LoginUserDto loginUserDto)
        {
            bool isValidUser;

            //Find the user
            var user = await _userManager.FindByEmailAsync(loginUserDto.Email);

            //Check the password
            isValidUser = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);

            //If user is null or invalid return null
            if(user == null || isValidUser == false)
            {
                return null;
            }

            //Generate the token
            var token = await GenerateToken(user);

            return new AuthResponseDto
            {   
                Token = token,
                UserId = user.Id
            };
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

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            //Get the security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            //Generate Credentials
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Get the users roles and get role claims
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            //Get user claims if they exist in the DB
            var userClaims = await _userManager.GetClaimsAsync(user);

            //Set the claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims).Union(roleClaims);

            //Create the token
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
