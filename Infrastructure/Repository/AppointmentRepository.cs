using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;
using Barberia.Backend.Domain.Enums;
using Barberia.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Backend.Infrastructure.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;
        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task<List<Appointment>> GetByStatusAsync(AppointmentStatus status)
        {
            return await _context.Appointments.Where(a => a.Status == status).ToListAsync();
        }
        public async Task<Appointment> UpdateStatusAsync(int appointmentId, AppointmentStatus status)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);

            if (appointment == null)
            {
                throw new Exception($"Cita con ID {appointmentId} no encontrada.");
            }
            appointment.Status = status;

            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<Appointment>> GetByBarberAndWorkDateAsync(int barberId, DateOnly workDate)
        {
            var startOfDay = workDate.ToDateTime(TimeOnly.MinValue);
            var endOfDay = startOfDay.AddDays(1);

            return await _context.Appointments.Where(a => a.BarberId == barberId && a.StartDateTime >= startOfDay && a.StartDateTime < endOfDay).ToListAsync();
        }
    }
}
