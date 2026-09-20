using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;
using Barberia.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Backend.Infrastructure.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;
        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetActiveAsync()
        {
            return await _context.Services.Where(s => s.IsActive).ToListAsync();
        }
        public async Task<Service?> GetByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
