using BlazorApp5.Models;

namespace BlazorApp5.Data;

public static class GymDbSeeder
{
    public static async Task SeedAsync(GymDbContext db)
    {
        if (db.Appointments.Any()) return;
        var today = DateTime.Today;
        db.Appointments.AddRange(
            Make("Maya Thompson", today, 6, 30, 7, 30, "Maya+T"),
            Make("Jordan Lee", today, 8, 0, 9, 0, "Jordan+L"),
            Make("Avery Brooks", today, 10, 15, 11, 15, "Avery+B"),
            Make("Noah Williams", today.AddDays(1), 7, 0, 8, 0, "Noah+W"),
            Make("Sofia Patel", today.AddDays(1), 17, 30, 18, 30, "Sofia+P"));
        await db.SaveChangesAsync();
    }
    private static Appointment Make(string name, DateTime date, int hour, int minute, int endHour, int endMinute, string initials) => new()
    {
        ClientName = name, GymName = "SDW Fitness Center", EventDate = date,
        AppointmentTime = date.AddHours(hour).AddMinutes(minute), CheckInTime = date.AddHours(hour).AddMinutes(minute), CheckOutTime = date.AddHours(endHour).AddMinutes(endMinute),
        AvatarUrl = $"https://placehold.co/96x96/dcf1e8/12372a?text={initials}"
    };
}
