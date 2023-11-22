using MXLogbookAPI.Models;

namespace MXLogbookAPI.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {

        //Mock Vehicles
        private static List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle {VehicleId = 0, VehicleMake = "Honda", VehicleModel="CRF250", VehicleYear = 2023, CreatedOn = DateTime.Now},
            new Vehicle {VehicleId = 1, VehicleMake = "Ford", VehicleModel = "F150", VehicleYear = 2018, CreatedOn= DateTime.Now},
        };

        private readonly IMapper _mapper;

        public VehicleService(IMapper mapper)
        {
            _mapper = mapper;
        }

        //Service Response gives us the options to add more data to responses
        public async Task<ServiceResponse<List<GetVehicleDto>>> GetAllVehicles()
        {
            var serviceResponse = new ServiceResponse<List<GetVehicleDto>>();
            serviceResponse.Data = vehicles.Select(v => _mapper.Map<GetVehicleDto>(v)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVehicleDto>> GetVehicleById(int vehicleId)
        {
            var serviceResponse = new ServiceResponse<GetVehicleDto>();
            var vehicle = vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
            serviceResponse.Data = _mapper.Map<GetVehicleDto>(vehicle);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVehicleDto>>> AddNewVehicle(AddVehicleDto newVehicle)
        {
            var serviceResponse = new ServiceResponse<List<GetVehicleDto>>();
            var vehicle = _mapper.Map<Vehicle>(newVehicle);

            // increment new id
            vehicle.VehicleId = vehicles.Max(v => v.VehicleId) + 1;

            vehicles.Add(vehicle);
            serviceResponse.Data = vehicles.Select(v => _mapper.Map<GetVehicleDto>(v)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVehicleDto>> UpdateVehicle(UpdateVehicleDto updateVehicle)
        {
            var serviceResponse = new ServiceResponse<GetVehicleDto>();

            try
            {
                var vehicle = vehicles.FirstOrDefault(v => v.VehicleId == updateVehicle.VehicleId);

                if (vehicle is null)
                    throw new Exception($"Vehicle with ID {updateVehicle.VehicleId} not found.");

                vehicle.VehicleMake = updateVehicle.VehicleMake;
                vehicle.VehicleModel = updateVehicle.VehicleModel;
                vehicle.VehicleYear = updateVehicle.VehicleYear;
                vehicle.Mileage = updateVehicle.Mileage;
                vehicle.Hours = updateVehicle.Hours;

                serviceResponse.Data = _mapper.Map<GetVehicleDto>(vehicle);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVehicleDto>>> DeleteVehicle(int vehicleId)
        {
            var serviceResponse = new ServiceResponse<List<GetVehicleDto>>();

            try
            {
                var vehicle = vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);

                if (vehicle is null)
                    throw new Exception($"Vehicle with ID {vehicleId} can not be found.");

                vehicles.Remove(vehicle);

                serviceResponse.Data = vehicles.Select(v => _mapper.Map<GetVehicleDto>(v)).ToList();
            } catch ( Exception ex )
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
