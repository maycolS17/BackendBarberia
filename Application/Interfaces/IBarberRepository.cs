using Barberia.Backend.Domain.Entities;

namespace Barberia.Backend.Application.Interfaces
{
    public interface IBarberRepository
    {
        Task<List<Barber>> GetActiveAsync();
        Task<Barber?> GetByIdAsync(int id);
    }
}
