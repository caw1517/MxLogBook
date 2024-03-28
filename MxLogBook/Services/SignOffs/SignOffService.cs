using Backend.Models;
using Backend.Data;
using Backend.DTOs.SignOff;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.SignOffs
{
    public class SignOffService : GenericService<SignOff>, ISignOffService
    {
        private readonly MxLogBookDbContext _dbContext;
        public SignOffService(MxLogBookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SignOff>> GetSignOffFromLog(int logId)
        {
            var res = await _dbContext.SignOffs.Include(q => q.User).Where(s => s.LogId == logId).ToListAsync();

            if (res.Count == 0)
                throw new InvalidOperationException("Not found");

            return res;
        }
    }
}
