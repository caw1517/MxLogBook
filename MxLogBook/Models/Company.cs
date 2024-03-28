using Backend.Models.RelationshipTables;

namespace Backend.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        
        //One to Many
        public virtual IList<Vehicle>? Vehicles { get; set; }
        
        //Many to Many
        public virtual IList<CompanyUserRoles> CompanyUserRoles { get; set; } = new List<CompanyUserRoles>();
        
    }
}
