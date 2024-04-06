using Backend.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Models.RelationshipTables;
using Backend.DTOs.Company;
using Backend.Migrations;

namespace Backend.Services.Companies
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        private readonly MxLogBookDbContext _dbContext;
        private readonly IAuthService _authService;
        private readonly ILogger<CompanyService> _logger;
        public CompanyService(MxLogBookDbContext dbContext, IAuthService authService, ILogger<CompanyService> logger) : base(dbContext)
        {
            _dbContext = dbContext;
            _authService = authService;
            _logger = logger;
        }

        public async Task<bool> AcceptInviteToken(AcceptInviteDto inviteToken)
        {
            //Get token
            var token = _dbContext.Invites.FirstOrDefault(i => i.TokenNumber == inviteToken.TokenNumber);

            if (token == null)
                return false;

            //Check if invite token is bad
            if (DateTime.UtcNow > token.ExpDate || !token.IsValidToken)
            {
                token.IsValidToken = false;
                _logger.LogCritical("Token Invalid or expired");
                return false;
            }
            //Find the user
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == token.UserId);

            //var user = await _authService.GetUserById(inviteToken.UserId);
            if (user == null)
            {
                _logger.LogCritical("User not found");
                return false;
            }

            //Find the company
            var company = await _dbContext.Companys.FirstOrDefaultAsync(c => c.Id == token.CompanyId);
            if (company == null)
            {
                _logger.LogCritical("Company not found");
                return false;
            }

            var isAlreadyPartOfCompany = await _dbContext.CompanyUserRoles.AnyAsync(cur => cur.UserId == user.Id && cur.CompanyId == company.Id);
            if(isAlreadyPartOfCompany)
            {
                _logger.LogCritical("User is already apart of the company");
                return false;
            }

            //Give companyuser role to user if he doesn't already have it
            var existingRoles = await _dbContext.CompanyUserRoles.AnyAsync(cur => cur.UserId == user.Id && cur.CompanyId == company.Id);
            if (existingRoles)
            {
                _logger.LogCritical($"User: ${user.UserName} already has a role in ${company.CompanyName}");
                return false;
            }
            //Assign the default role
            var defaultRole = await _dbContext.CompanyRoles.FirstOrDefaultAsync(r => r.RoleType == RoleType.Member);

            if(defaultRole == null)
            {
                _logger.LogCritical("Role not found");
                return false;
            }

            //Add the new role
            _dbContext.CompanyUserRoles.Add(new CompanyUserRoles
            {
               UserId = user.Id,
               CompanyId = company.Id,
               RoleId = defaultRole.Id
            });

            //Save user to db
            token.IsValidToken = false;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<int>> GetUsersCompanyId(string userId)
        {
            var companies = await _dbContext.CompanyUserRoles
                .Where(c => c.UserId == userId)
                .Select(c => c.CompanyId)
                .ToListAsync();

            if (companies.Count == 0)
                return new List<int>();
            
            return companies;
        }

        public async Task<bool> VerifyUserInCompany(string userId, int companyId)
        {
            var company = await _dbContext.CompanyUserRoles
                .Where(c => c.CompanyId == companyId && c.UserId == userId).ToListAsync();
            
            return company.Count != 0;
        }

        public async Task<List<int>> GetUserRolesInCompany(string userId, int companyId)
        {
            var roles = await _dbContext.CompanyUserRoles
                .Where(c => c.CompanyId == companyId && c.UserId == userId)
                .Select(r => r.RoleId)
                .ToListAsync();

            return roles.Count > 0 ? roles : [];
        }

        public async Task<List<Company>> GetUsersCompanies(string userId)
        {
            //var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == userId);
            
            var companies = await _dbContext.CompanyUserRoles.Where(c => c.UserId == userId)
                .Select(c => c.Company)
                .ToListAsync();
            
            if (companies.Count == 0) throw new InvalidOperationException();
            
            return companies;
        }

        public async Task<Models.InviteToken> CreateInviteToken(Models.InviteToken inviteToken)
        {


            //Generate the new id
            inviteToken.TokenNumber = Guid.NewGuid().ToString();

            await _dbContext.AddAsync(inviteToken);
            await _dbContext.SaveChangesAsync();

            return inviteToken;
        }

        public async Task<List<Company>> GetAll()
        {
            var res = await _dbContext.Companys.ToListAsync();
            //.Include(q => q.ApplicationUsers)

            if (res.Count <= 0)
                return null;

            return res;
        }

        public async Task<Company> GetById(int id)
        {
            var res = await _dbContext.Companys.FirstOrDefaultAsync(x => x.Id == id);
            //.Include(q => q.ApplicationUsers)

            return res;
        }
    }
}
