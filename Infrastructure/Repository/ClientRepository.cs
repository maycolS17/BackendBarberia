using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;
using Barberia.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Backend.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }
        public async Task<Client?> GetByPhoneAsync(string phone)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Phone == phone);
        }
    }
}
