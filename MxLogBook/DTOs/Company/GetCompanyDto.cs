using Backend.DTOs.Auth;
using Backend.Models;

namespace Backend.DTOs.Company
{
    public class GetCompanyDto
    {

        public int Id { get; set; }
        public string? CompanyName { get; set; }
        //Many - Many
        public virtual IList<GetUserBasicDto> ApplicationUsers { get; set; }
    }
}

