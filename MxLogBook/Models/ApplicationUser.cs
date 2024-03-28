using Backend.Models.RelationshipTables;
using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        //One - Many
        public virtual IList<Vehicle>? Vehicles { get; set; }
        public virtual IList<LogItem>? LogItems { get; set; } 
        public virtual IList<SignOff>? SignOffs { get; set; }
        
        //Many - Many
        public virtual IList<CompanyUserRoles> CompanyUserRoles { get; set; } = new List<CompanyUserRoles>();
    }
}
