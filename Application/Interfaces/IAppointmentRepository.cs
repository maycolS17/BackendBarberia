using Barberia.Backend.Domain.Entities;
using Barberia.Backend.Domain.Enums;

namespace Barberia.Backend.Application.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> CreateAsync(Appointment appointment);
        Task<List<Appointment>> GetByStatusAsync(AppointmentStatus status);
        Task<Appointment> UpdateStatusAsync(int id, AppointmentStatus status);
        Task<Appointment?> GetByIdAsync(int id);
        Task<List<Appointment>> GetByBarberAndWorkDateAsync(int barberId, DateOnly workDate);
    }
}
