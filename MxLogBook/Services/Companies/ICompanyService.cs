using Backend.DTOs.Company;
using Backend.Models;

namespace Backend.Services.Companies
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<List<Company>> GetAll();
        Task<Company> GetById(int id);
        Task<InviteToken> CreateInviteToken(InviteToken inviteToken);
        Task<bool> AcceptInviteToken(AcceptInviteDto inviteToken);
        Task<List<int>> GetUsersCompanyId(string userId);
        
        Task<bool> VerifyUserInCompany(string userId, int companyId);
        Task<List<int>> GetUserRolesInCompany(string userId, int companyId);

        Task<List<Company>> GetUsersCompanies(string userId);
    }
}
