namespace Backend.Models.RelationshipTables
{
    public class CompanyUserRoles
    {
        public string? UserId;
        public int CompanyId;
        public int RoleId;
        public ApplicationUser ApplicationUser;
        public Company Company;
        public Roles Role;
    }
}
