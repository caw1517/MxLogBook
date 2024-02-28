using Backend.DTOs.Auth;
using Backend.Models;

namespace Backend.DTOs.Company
{
    public class CreateCompanyDto
    {

        public int Id { get; set; }
        public string? CompanyName { get; set; }
    }
}

