using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;
using Barberia.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Backend.Infrastructure.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _context;
        public ScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Schedule?> GetByIdAsync(int id)
        {
            return await _context.Schedules.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Schedule>> GetActiveByBarberAndWorkDateAsync(int barberId, DateOnly workDate)
        {
            return await _context.Schedules.Where(s => s.IsActive && s.BarberId == barberId && s.WorkDate == workDate).ToListAsync();
        }
    }
}
