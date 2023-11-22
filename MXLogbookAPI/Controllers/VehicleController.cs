using Microsoft.AspNetCore.Mvc;
namespace MXLogbookAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VehicleController : ControllerBase
    {
        //Init the vehicle service via DI
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this._vehicleService = vehicleService;
        }

        //Get All Vehicles
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetVehicleDto>>>> GetAllVehicles()
        {
            return Ok(await _vehicleService.GetAllVehicles());
        }

        //Get Single Vehicle By ID
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ServiceResponse<GetVehicleDto>>> GetSinlge(int id)
        {
            return Ok(await _vehicleService.GetVehicleById(id));
        }

        [HttpPost]
        //Returning all characters?? Alter possibly
        public async Task<ActionResult<ServiceResponse<List<GetVehicleDto>>>> NewVehicle(AddVehicleDto newVehicle)
        {
            return Ok(await _vehicleService.AddNewVehicle(newVehicle));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetVehicleDto>>> UpdateVehicle(UpdateVehicleDto updateVehicle)
        {
            var response = await _vehicleService.UpdateVehicle(updateVehicle);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{vehicleId}")]
        public async Task<ActionResult<ServiceResponse<List<GetVehicleDto>>>> DeleteVehicle(int vehicleId)
        {
            var response = await _vehicleService.DeleteVehicle(vehicleId);

            if(response.Data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
