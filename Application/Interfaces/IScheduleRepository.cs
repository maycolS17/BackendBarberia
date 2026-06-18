using Barberia.Backend.Domain.Entities;

namespace Barberia.Backend.Application.Interfaces
{
    public interface IScheduleRepository
    {
        Task<Schedule?> GetByIdAsync(int id);

        Task<List<Schedule>> GetActiveByBarberAndDateAsync(int BarberId, DateOnly WorkDate);
    }
}
