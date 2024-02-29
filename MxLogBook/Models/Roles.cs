using Backend.Models.RelationshipTables;

namespace Backend.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public RoleType RoleType { get; set; }
        public virtual IList<CompanyUserRoles> CompanyUserRoles { get; set; } = new List<CompanyUserRoles>();
    }

    public enum RoleType
    {
        Viewer = 1,
        Member = 2,
        Admin = 3
    }
}
