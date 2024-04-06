using AutoMapper;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Services.Companies;
using Backend.DTOs.Company;
using System.Security.Claims;
using Backend.DTOs.Auth;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly IAuthService _authService;

        public CompanyController(IMapper mapper, ICompanyService companyService, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
            _companyService = companyService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<GetCompanyDto>>> GetCompanies()
        {
            var companies = await _companyService.GetAll();
            var records = _mapper.Map<List<GetCompanyDto>>(companies);

            return Ok(records);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<GetCompanyDto>> GetCompanyById(int id)
        {
            var company = await _companyService.GetById(id);
            var res = _mapper.Map<GetCompanyDto>(company);

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<GetCompanyDto>> AddCompany(CreateCompanyDto newCompany)
        {
            var company = _mapper.Map<Company>(newCompany);

            await _companyService.AddAsync(company);

            return Ok(company);
        }

        [HttpPost("/invite")]
        [Authorize(Roles = "Administrator,CompanyAdmin")]
        public async Task<ActionResult<GetInviteTokenDto>> CreateInviteToken(CreateInviteTokenDto newInvite)
        {
            //Verify user exists
            bool user = await _authService.UserExists(newInvite.UserId);
            if (!user)
                return NotFound("User not found");

            //Map the invite dto
            var invite = _mapper.Map<InviteToken>(newInvite);

            //Create the token in db
            await _companyService.CreateInviteToken(invite);

            //ADD - Map the return to a get token
            var res = _mapper.Map<GetInviteTokenDto>(invite);

            //Return
            return Ok(res);
            
        }

        [HttpPost("/acceptInvite")]
        public async Task<ActionResult> AcceptInvite(AcceptInviteDto inviteToken)
        {
            var res = await _companyService.AcceptInviteToken(inviteToken);

            if (res == true)
                return Ok("Company Added");

            return BadRequest();
        }

        [HttpGet]
        [Route("userCompanies")]
        public async Task<ActionResult<List<GetCompanyWithoutUserDto>>> GetUsersCompanies()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;

            var res = await _companyService.GetUsersCompanies(userIdClaim);

            var mappedRes = _mapper.Map<List<GetCompanyWithoutUserDto>>(res);

            return mappedRes;
        }
    }
}
