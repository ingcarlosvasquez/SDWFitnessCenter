using BlazorApp5.Data;
using BlazorApp5.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp5.Services;

public class AppointmentService(IDbContextFactory<GymDbContext> factory)
{
    public async Task<List<Appointment>> GetAllAsync()
    {
        await using var db = await factory.CreateDbContextAsync();
        return await db.Appointments.AsNoTracking().OrderBy(a => a.EventDate).ThenBy(a => a.AppointmentTime).ToListAsync();
    }
    public async Task SaveAsync(Appointment appointment)
    {
        await using var db = await factory.CreateDbContextAsync();
        appointment.GymName = "SDW Fitness Center";
        if (appointment.Id == 0) { if (string.IsNullOrWhiteSpace(appointment.AvatarUrl)) appointment.AvatarUrl = "https://placehold.co/96x96/e4f4ed/12372a?text=NEW"; db.Appointments.Add(appointment); }
        else db.Appointments.Update(appointment);
        await db.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        await using var db = await factory.CreateDbContextAsync();
        var appointment = await db.Appointments.FindAsync(id);
        if (appointment is not null) { db.Appointments.Remove(appointment); await db.SaveChangesAsync(); }
    }
}
