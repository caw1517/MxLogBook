using Backend.Models.RelationshipTables;

namespace Backend.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public virtual IList<CompanyUserRoles> CompanyUserRoles { get; set; } = new List<CompanyUserRoles>();   
    }
}
