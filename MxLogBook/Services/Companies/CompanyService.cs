using Backend.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Models.RelationshipTables;
using Backend.DTOs.Company;

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

            //Check if invite token is bad
            if (DateTime.UtcNow > token.ExpDate)
            {
                token.IsValidToken = false;
                _logger.LogCritical("Token Invalid");
                return false;
            }
            //Find the user
            var user = await _dbContext.Users.Include(u => u.Companies).FirstOrDefaultAsync(u => u.Id == token.UserId);
            //var user = await _authService.GetUserById(inviteToken.UserId);
            if (user == null)
                return false;

            //Find the company
            var company = await GetAsync(inviteToken.CompanyId);
            if (company == null)
                return false;

            //Give companyuser role to user if he doesn't already have it
            var roles = await _authService.GetUserRoles(user);
            if (!roles.Contains("CompanyUser"))
                await _authService.AddUserRole(user, "CompanyUser");

            if (user.Companies.Any(c => c.Id == token.CompanyId))
            {
                _logger.LogInformation($"User {user.Id} is already a part of company {inviteToken.CompanyId}.");
                token.IsValidToken = false;
                await _dbContext.SaveChangesAsync();
                return false; // No need to proceed further
            }

            //Save user to db
            token.IsValidToken = false;
            user.Companies.Add(company);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<InviteToken> CreateInviteToken(InviteToken inviteToken)
        {


            //Generate the new id
            inviteToken.TokenNumber = Guid.NewGuid().ToString();

            await _dbContext.AddAsync(inviteToken);
            await _dbContext.SaveChangesAsync();

            return inviteToken;
        }

        public async Task<List<Company>> GetAll()
        {
            var res = await _dbContext.Companys.Include(q=> q.ApplicationUsers).ToListAsync();

            if (res.Count <= 0)
                return null;

            return res;
        }

        public async Task<Company> GetById(int id)
        {
            var res = await _dbContext.Companys.Include(q => q.ApplicationUsers).FirstOrDefaultAsync(x => x.Id == id);

            return res;
        }
    }
}
