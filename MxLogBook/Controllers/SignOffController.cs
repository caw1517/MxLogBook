using AutoMapper;
using Backend.DTOs.SignOff;
using Backend.DTOs.Vehicles;
using Backend.Models;
using Backend.Services;
using Backend.Services.SignOffs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public SignOffController(IMapper mapper, ILogItemService logItemService, ISignOffService signOffService)
        {
            _mapper = mapper;
            _logItemService = logItemService;
            _signOffService = signOffService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetSignOffDto>> GetSignOff(int id)
        {
            var signOff = await _signOffService.GetAsync(id);

            if (signOff == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetSignOffDto>(signOff);

            return Ok(result);
        }

        [HttpPost("{logId}")]
        [Authorize]
        public async Task<ActionResult<SignOff>> CreateNewSignOff(int logId, NewSignOffDto newSignOff)
        {
            //Make sure user owns vehicle / is in company that owns it
            //Get the user id from the header
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity.FindFirst("uid").Value;

            //Check if the signoff closes the log item
            if (newSignOff.CompletesItem == true)
                await _logItemService.SetLogItemStatus(logId, newSignOff.CompletesItem);

            //Set user id and log id
            newSignOff.UserId = userIdClaim;

            newSignOff.LogId = logId;

            //Map the object
            var signOff = _mapper.Map<SignOff>(newSignOff);

            //Add the sign off
            await _signOffService.AddAsync(signOff);

            return CreatedAtAction("GetSignOff", new { id = signOff.Id }, newSignOff);
        }
    }
}
