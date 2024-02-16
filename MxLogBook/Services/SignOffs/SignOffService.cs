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
    }
}
