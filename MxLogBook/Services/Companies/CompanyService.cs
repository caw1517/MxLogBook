using Backend.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Companies
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        private readonly MxLogBookDbContext _dbContext;
        public CompanyService(MxLogBookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Company>> GetAll()
        {
            var res = await _dbContext.Companys.Include(q=> q.ApplicationUsers).ToListAsync();

            return res;
        }

        public async Task<Company> GetById(int id)
        {
            var res = await _dbContext.Companys.Include(q => q.ApplicationUsers).FirstOrDefaultAsync(x => x.Id == id);

            return res;
        }
    }
}
