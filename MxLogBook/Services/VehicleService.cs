using Backend.Services;
using Backend.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class VehicleService : GenericService<Vehicle>, IVehicleService
    {
        private readonly MxLogBookDbContext _dbContext;
        public VehicleService(MxLogBookDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Vehicle> GetDetails(int id)
        {
            //Will return null if value can not be found
            var res = await _dbContext.Vehicles.Include(q => q.LogItems).FirstOrDefaultAsync(q => q.Id == id);
            
            if (res == null)
                return null;

            return res;
        }

        public async Task<List<Vehicle>> GetVehiclesByUserId(string userId)
        {
            var res = await _dbContext.Vehicles.Include(q => q.LogItems).Where(v => v.UserId == userId).ToListAsync();

            if (res == null)
                return null;

            return res;
        }
    }
}
