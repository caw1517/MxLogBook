namespace Backend.Models.RelationshipTables
{
    public class CompanyUser
    {
        public string? UserId;
        public int CompanyId;
        public ApplicationUser ApplicationUser;
        public Company Company;
    }
}
