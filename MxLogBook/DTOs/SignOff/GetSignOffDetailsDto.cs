using Backend.DTOs.Auth;
using Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs.SignOff
{
    public class GetSignOffDetailsDto
    {
        public string? WorkPerformed { get; set; }
        public DateTime CompletedAt { get; set; }
        public bool CompletesItem { get; set; }
        public GetUserBasicDto? User { get; set; }

    }
}
