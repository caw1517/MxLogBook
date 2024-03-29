﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.DTOs.Vehicles;
using AutoMapper;
using Backend.Services;
using System.Security.Claims;
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


        public VehiclesController (IMapper mapper, IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        // GET: ADMIN ONLY - THINK ABOUT DELETING
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetVehicleDto>>> GetVehicles()
        {

            var vehicles = await _vehicleService.GetAllAsync();
            var records = _mapper.Map<List<GetVehicleDto>>(vehicles);
            return Ok(records);
        }

        //GET: USED BY FRONTEND TO GET A SPECIFIC USERS VEHICLE
        [HttpGet("user/")]
        public async Task<ActionResult<IEnumerable<GetVehicleDetailsDto>>> GetVehiclesByUserId()
        {
            //Get the user id from the header
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity.FindFirst("uid").Value;

            var vehicles = await _vehicleService.GetVehiclesByUserId(userIdClaim);
            var records = _mapper.Map<List<GetVehicleDetailsDto>>(vehicles);

            return Ok(records);
        }

        // GET: USED BY FRONTEND TO GET A SPECIFIC LOG ITEM
        [HttpGet("{id}")]
        public async Task<ActionResult<GetVehicleDetailsDto>> GetVehicle(int id)
        {
            var vehicle = await _vehicleService.GetDetails(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetVehicleDetailsDto>(vehicle);

            return Ok(result);
        }

        // PUT: USED TO UPDATE VEHICLE OVERALL - ITEMS LIKE MILEAGE SHOULD BE HANDLED BY FUNCTIONS LIKE SIGNOFFS
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, UpdateVehicleDto updatedVehicle)
        {
            if (id != updatedVehicle.Id)
            {
                return BadRequest("Invalid Vehicle Id");
            }

            var vehicle = await _vehicleService.GetAsync(id);
            //var vehicle = await _context.vehicles.FirstOrDefaultAsync(q => q.Id == id);

            if(vehicle == null)
            {
                return NotFound();
            }

            //Map the updated vehicle to the vehicle
            _mapper.Map(updatedVehicle, vehicle);

            try
            {
                await _vehicleService.UpdateAsync(vehicle);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: CREATE A NEW VEHICLE
        [HttpPost]
        public async Task<ActionResult<Vehicle>> AddVehicle(AddVehicleDto newVehicle)
        {
            //Map Vehicle DTO
            var vehicle = _mapper.Map<Vehicle>(newVehicle);

            //Save the new vehicle
            await _vehicleService.AddAsync(vehicle);

            //Return the newly created vehicle
            return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: DELETE A VEHICLE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _vehicleService.GetAsync(id);

            if (vehicle == null)
                return NotFound();
       

            await _vehicleService.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> VehicleExists(int id)
        {
            return await _vehicleService.Exists(id);
        }
    }
}
