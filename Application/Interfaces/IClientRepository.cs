using Barberia.Backend.Domain.Entities;

namespace Barberia.Backend.Application.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> CreateAsync(Client client);
        Task<Client?> GetByPhoneAsync(string phone);
    }
}
