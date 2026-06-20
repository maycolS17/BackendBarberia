using Barberia.Backend.Domain.Entities;
using Barberia.Backend.Domain.Enums;

namespace Barberia.Backend.Application.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> CreateAsync(Appointment appointment);
        Task<List<Appointment>> GetByStatusAsync(AppointmentStatus status);
        Task<Appointment> UpdateAsync(Appointment appointment);
    }
}
