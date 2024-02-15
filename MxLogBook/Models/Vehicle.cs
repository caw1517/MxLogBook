﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string?  Model { get; set; }
        public int Year { get; set; }
        public int? Mileage { get; set; }
        public int? Hours { get; set; }
        //Default Timestamp
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        //User Relation - One User To Many Vehicles
        [Required]
        public string? UserId { get; set; }

        //Log Item Relation - One To Many
        public virtual IList<LogItem>? LogItems { get; set; }
    }
}
