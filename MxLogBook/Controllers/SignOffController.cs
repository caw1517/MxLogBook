using AutoMapper;
using Backend.DTOs.SignOff;
using Backend.Models;
using Backend.Services;
using Backend.Services.SignOffs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignOffController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogItemService _logItemService;
        private readonly ISignOffService _signOffService;
        private readonly IVehicleService _vehicleService;

        public SignOffController(IMapper mapper, ILogItemService logItemService, ISignOffService signOffService, IVehicleService vehicleService)
        {
            _mapper = mapper;
            _logItemService = logItemService;
            _signOffService = signOffService;
            _vehicleService = vehicleService;
        }

        [HttpGet("{signOffId:int}")]
        public async Task<ActionResult<GetSignOffDto>> GetSignOff(int signOffId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;
            try
            {
                var signOff = await _signOffService.GetAsync(signOffId);

                var vehicle = await _logItemService.GetAsync(signOff.LogId);
                var vehicleId = vehicle.VehicleId;

                if (await _vehicleService.VerifyVehicleOwner(userIdClaim, vehicleId) == false)
                    return BadRequest(new { message = "Invalid vehicle owner" });

                var result = _mapper.Map<GetSignOffDto>(signOff);

                return Ok(result);
            }
            catch (InvalidOperationException e)
            {
                return NotFound("Sign off not found.");
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(new { message = "Must supply a sign off id." });
            }
            
            
        }

        [HttpGet("signoffbylog/{logId:int}")]
        [Authorize]
        public async Task<ActionResult<List<GetSignOffDetailsDto>>> GetSignOffByLog(int logId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;
            
            try
            {
                var log = await _logItemService.GetAsync(logId);
                if (await _vehicleService.VerifyVehicleOwner(userIdClaim, log.VehicleId) == false)
                    return BadRequest(new { message = "Invalid vehicle owner" });
                
                var signOffs = await _signOffService.GetSignOffFromLog(logId);

                var result = _mapper.Map<List<GetSignOffDetailsDto>>(signOffs);
                return Ok(result);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(new { message = "Sign offs not found" });
            }
        }
        
        [HttpPost("{logId:int}")]
        [Authorize]
        public async Task<ActionResult<NewSignOffDto>> CreateNewSignOff(int logId, NewSignOffDto newSignOff)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;

            if (newSignOff.CompletesItem == true)
                await _logItemService.SetLogItemStatus(logId, newSignOff.CompletesItem);

            newSignOff.UserId = userIdClaim;
            newSignOff.LogId = logId;

            var signOff = _mapper.Map<SignOff>(newSignOff);

            await _signOffService.AddAsync(signOff);

            return Ok(new {message = "Sign off successfully created"});
        }
    }
}
