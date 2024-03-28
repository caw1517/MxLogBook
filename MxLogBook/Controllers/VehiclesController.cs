using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.DTOs.Vehicles;
using AutoMapper;
using Backend.Services;
using System.Security.Claims;
using Backend.Services.Companies;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehiclesController : ControllerBase
    {
        //Private
        private readonly IMapper _mapper;
        private readonly IVehicleService _vehicleService;
        private readonly ICompanyService _companyService;

        public VehiclesController (IMapper mapper, IVehicleService vehicleService, ICompanyService companyService)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
            _companyService = companyService;
        }

        // GET: ADMIN ONLY - THINK ABOUT DELETING
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<GetVehicleDto>>> GetVehicles()
        {

            var vehicles = await _vehicleService.GetAllAsync();
            var records = _mapper.Map<List<GetVehicleDto>>(vehicles);
            return Ok(records);
        }
        
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<GetVehicleDetailsDto>>> GetVehiclesByUserId()
        {
            //Get the user id from the header
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;

            //Get the vehicles
            var vehicles = await _vehicleService.GetVehiclesByUserId(userIdClaim);
            var records = _mapper.Map<List<GetVehicleDetailsDto>>(vehicles);

            //Return Ok
            return Ok(records);
        }
        
        [HttpGet("{vehicleId}")]
        public async Task<ActionResult<GetVehicleDetailsDto>> GetVehicle(int vehicleId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;

            if (await _vehicleService.VerifyVehicleOwner(userIdClaim, vehicleId) == false)
                return BadRequest(new {message = "Invalid Vehicle Owner"});
            
            var vehicle = await _vehicleService.GetDetails(vehicleId);

            if (vehicle is null)
                return NotFound();
            
            var result = _mapper.Map<GetVehicleDetailsDto>(vehicle);

            return Ok(result);
        }

        [HttpGet("vehiclesByAllCompanies")]
        public async Task<ActionResult<IEnumerable<GetVehicleDetailsDto>>> GetVehicleByAllCompanyForUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;
            
            var companies = await _companyService.GetUsersCompanyId(userIdClaim);
            
            if (companies.Count == 0)
                return NotFound(new {message = "User is not apart of any companies."});

            var vehiclesList = new List<Vehicle>();
            
            foreach (var company in companies)
            {
                vehiclesList.AddRange(await _vehicleService.GetVehiclesByCompanyId(company));
            }
            
            if (vehiclesList.Count == 0)
                return NotFound(new {message = "No vehicles assigned to that company"});

            var res = _mapper.Map<List<GetVehicleDetailsDto>>(vehiclesList);

            return Ok(res);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, UpdateVehicleDto updatedVehicle)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity!.FindFirst("uid")!.Value;

            if (await _vehicleService.VerifyVehicleOwner(userId, id) == false)
                return BadRequest(new {message = "Invalid Vehicle Owner"});

            if (id != updatedVehicle.Id)
                return BadRequest(new {message = "Invalid Vehicle Id"});

            var vehicle = await _vehicleService.GetAsync(id);

            _mapper.Map(updatedVehicle, vehicle);

            await _vehicleService.UpdateAsync(vehicle);

            return Ok();
        }
        
        [HttpPost]
        public async Task<ActionResult<Vehicle>> AddVehicle(AddVehicleDto newVehicle)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;
            
            var vehicle = _mapper.Map<Vehicle>(newVehicle);

            vehicle.UserId = userIdClaim;
            
            await _vehicleService.AddAsync(vehicle);

            return Ok(newVehicle);
            //return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;
            
            try
            {
                var vehicle = await _vehicleService.GetAsync(id);

                if (userIdClaim != vehicle.UserId)
                    return BadRequest(new { message = "Must be owner of vehicle to delete" });
       
                await _vehicleService.DeleteAsync(id);

                return Ok("Vehicle Deleted Successfully.");
            }
            catch (InvalidOperationException)
            {
                return NotFound(new { message = "Vehivle not found" });
            }
        }
    }
}
