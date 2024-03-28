using Backend.Services;
using Backend.Models;
using Backend.Data;
using Backend.Services.Companies;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class VehicleService : GenericService<Vehicle>, IVehicleService
    {
        private readonly MxLogBookDbContext _dbContext;
        private readonly ICompanyService _companyService;
        public VehicleService(MxLogBookDbContext context, ICompanyService companyService) : base(context)
        {
            _dbContext = context;
            _companyService = companyService;
        }

        public async Task<Vehicle?> GetDetails(int id)
        {
            var res = await _dbContext.Vehicles
                .Include(q => q.LogItems)!
                .ThenInclude(li => li.User)
                .FirstOrDefaultAsync(q => q.Id == id);
            
            if (res is null)
                return null;

            return res;
        }

        public async Task<List<Vehicle>> GetVehiclesByUserId(string userId)
        {
            var res = await _dbContext.Vehicles
                .Include(q => q.LogItems)!
                .ThenInclude(li => li.User)
                .Where(v => v.UserId == userId)
                .ToListAsync();

            return res.Count > 0 ? res : [];
        }

        public async Task<List<Vehicle>> GetVehiclesByCompanyId(int companyId)
        {
            var vehicles = await _dbContext.Vehicles
                .Include(q=> q.LogItems)!
                .ThenInclude(li => li.User)
                .Where(v => v.CompanyId == companyId)
                .ToListAsync();

            return vehicles.Count > 0 ? vehicles : [];
        }

        public async Task<bool> VerifyVehicleOwner(string userId, int vehicleId)
        {
            var vehicle = await _dbContext.Vehicles
                .FirstOrDefaultAsync(v => v.Id == vehicleId);
            
            if (vehicle == null)
                return false;

            var userCompanies = await _companyService.GetUsersCompanyId(userId);

            return vehicle.UserId == userId || userCompanies.Contains((int)vehicle.CompanyId!);
        }
    }
}
