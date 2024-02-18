using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class LogItem
    {
        public int Id { get; set; }
        //TODO - Add Task Item Relation
        public string? Discrepency { get; set; }
        //Change to Enum Later
        public bool Closed { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ClosedOn { get; set; }

        //User Relation - Act as One To Many
        [ForeignKey(nameof(UserId))]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        //Vehicle One to Many Relation
        [ForeignKey(nameof(VehicleId))]
        public int VehicleId { get; set; }
        public  Vehicle? Vehicle { get; set; }

        //Sign Off Relation
        public virtual IList<SignOff> SignOffs { get; set; }
    }
}
