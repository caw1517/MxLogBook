namespace Backend.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string?  Model { get; set; }
        public int Year { get; set; }
        //Maybe this is supposed to be Car/Bike/Etc...
        //public string? Type { get; set; }
        public int? Mileage { get; set; }
        public int? Hours { get; set; }

        //Default Timestamp
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        //Log Item Relation - One To Many
        public virtual IList<LogItem>? LogItems { get; set; }


    }
}
