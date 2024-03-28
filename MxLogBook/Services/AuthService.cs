using AutoMapper;
using Backend.Data;
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
        private ApplicationUser _user;
        private readonly MxLogBookDbContext _dbContext;

        public AuthService(IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration, MxLogBookDbContext dbContext)
        {
            _mapper = mapper;   
            _userManager = userManager;
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<string> CreateRefreshToken()
        {
            //Remove previous token
            await _userManager.RemoveAuthenticationTokenAsync(_user, "MxLogBookApi", "RefreshToken");

            //Make new refresh token
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, "MxLogBookApi", "RefreshToken");

            var result = await _userManager.SetAuthenticationTokenAsync(_user, "MxLogBookApi", "RefreshToken", newRefreshToken);

            return newRefreshToken;
        }

        public async Task<AuthResponseDto> LoginUser(LoginUserDto loginUserDto)
        {
            //Find the user
            _user = await _userManager.FindByEmailAsync(loginUserDto.Email);

            //Check the password
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, loginUserDto.Password);

            //If user is null or invalid return null
            if(_user == null || isValidUser == false)
            {
                return null;
            }

            //Generate the token
            var token = await GenerateToken();

            return new AuthResponseDto
            {
                Token = token,
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken()
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


        public async Task<bool> UserExists(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
                return true;

            return false;
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Sub)?.Value;

            //Find the user
            _user = await _userManager.FindByNameAsync(username);

            if (_user == null || _user.Id != request.UserId)
                return null;

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, "MxLogBookApi", "RefreshToken", request.RefreshToken);

            //If it is valid
            if (isValidRefreshToken)
            {
                //Generate new token
                var token = await GenerateToken();

                return new AuthResponseDto
                {
                    Token = token,
                    UserId = _user.Id,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }

        private async Task<string> GenerateToken()
        {
            //Get the security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            //Generate Credentials
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Get the users roles and get role claims
            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            //Get user claims if they exist in the DB
            var userClaims = await _userManager.GetClaimsAsync(_user);

            //Set the claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid", _user.Id)
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

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            return user;
        }

        public async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            return userRoles.ToList();
        }

        public async Task<bool> AddUserRole(ApplicationUser user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);

            return true;
        }
    }
}
