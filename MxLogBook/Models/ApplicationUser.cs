using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        //Vehicle Relation
        public virtual IList<Vehicle>? Vehicles { get; set; }

        public virtual IList<LogItem>? LogItems { get; set; } 
    }
}
