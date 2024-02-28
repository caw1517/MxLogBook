using Backend.Models;

namespace Backend.Services.Companies
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<List<Company>> GetAll();
        Task<Company> GetById(int id);
    }
}
