using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;
using Barberia.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Backend.Infrastructure.Repository
{
    public class BarberRepository : IBarberRepository
    {
        private readonly AppDbContext _context;
        public BarberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Barber>> GetActiveAsync()
        {
            return await _context.Barbers.Where(b => b.IsActive).ToListAsync();
        }
        public async Task<Barber?> GetByIdAsync(int id)
        {
            return await _context.Barbers.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
