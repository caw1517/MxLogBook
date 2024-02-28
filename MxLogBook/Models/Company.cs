using Backend.Models.RelationshipTables;

namespace Backend.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        //Many - Many
        public virtual IList<ApplicationUser> ApplicationUsers{ get; set; }
    }
}
