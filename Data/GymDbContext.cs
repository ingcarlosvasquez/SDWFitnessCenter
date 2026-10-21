using BlazorApp5.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp5.Data;

public class GymDbContext(DbContextOptions<GymDbContext> options) : DbContext(options)
{
    public DbSet<Appointment> Appointments => Set<Appointment>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>().Property(a => a.ClientName).HasMaxLength(80);
        modelBuilder.Entity<Appointment>().Property(a => a.GymName).HasMaxLength(120);
        modelBuilder.Entity<Appointment>().Property(a => a.AvatarUrl).HasMaxLength(300);
    }
}
