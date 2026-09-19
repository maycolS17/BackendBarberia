using Microsoft.EntityFrameworkCore;
using Barberia.Backend.Domain.Entities;

namespace Barberia.Backend.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Barber> Barbers { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
    }
}
