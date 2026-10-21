using System.ComponentModel.DataAnnotations;

namespace BlazorApp5.Models;

public class Appointment
{
    public int Id { get; set; }
    [Required, StringLength(80)] public string ClientName { get; set; } = string.Empty;
    [Required, StringLength(120)] public string GymName { get; set; } = "SDW Fitness Center";
    [Required] public DateTime EventDate { get; set; }
    [Required] public DateTime AppointmentTime { get; set; }
    [Required] public DateTime CheckInTime { get; set; }
    [Required] public DateTime CheckOutTime { get; set; }
    [StringLength(300)] public string AvatarUrl { get; set; } = string.Empty;
    public Appointment Clone() => (Appointment)MemberwiseClone();
}
