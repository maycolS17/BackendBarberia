using Barberia.Backend.Domain.Entities;

namespace Barberia.Backend.Application.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetActiveAsync();
        Task<Service?> GetByIdAsync(int id);
    }
}
