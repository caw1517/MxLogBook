using Backend.DTOs.Auth;

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

