using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;

namespace Barberia.Backend.Application.Services
{
    public class ScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Schedule> GetByIdAsync(int id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);

            if (schedule == null)
                throw new Exception("Horario no encontrado.");

            if (!schedule.IsActive)
                throw new Exception("Horario no activo.");

            return schedule;
        }

        public async Task<List<Schedule>> GetActiveByBarberAndWorkDateAsync(int barberId, DateOnly workDate)
        {
            var schedules = await _scheduleRepository.GetActiveByBarberAndWorkDateAsync(barberId, workDate);

            return schedules;
        }
    }
}
