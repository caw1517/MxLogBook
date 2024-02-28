using AutoMapper;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Services.Companies;
using Backend.DTOs.Company;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }

        //GET: USED TO VIEW A LIST OF ALL COMPANIES - ADMIN ONLY
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<GetCompanyDto>>> GetCompanies()
        {
            var companies = await _companyService.GetAll();
            var records = _mapper.Map<List<GetCompanyDto>>(companies);

            return Ok(records);
        }

        //GET: GET A COMPANY BY COMPANY ID
        [HttpGet("/{id}")]
        public async Task<ActionResult<GetCompanyDto>> GetCompanyById(int id)
        {
            var company = await _companyService.GetById(id);
            var res = _mapper.Map<GetCompanyDto>(company);

            return Ok(res);
        }

        //POST: CREATE A COMPANY - ANY USER
        [HttpPost]
        public async Task<ActionResult<GetCompanyDto>> AddCompany(CreateCompanyDto newCompany)
        {
            var company = _mapper.Map<Company>(newCompany);

            await _companyService.AddAsync(company);

            return Ok(company);
        }

        //POST: SEND USER INVITE TO COMPANY - COMPANY ADMIN
        /*
         
        //
         
         */


        //POST: ACCEPT INVITE FOR COMPANY - ANY USER

        //PUT: UPDATE COMAPNY - COMPANY ADMIN

        //DELETE: DELETE A COMPANY - COMPANY ADMIN
    }
}
