using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;

namespace Barberia.Backend.Application.Services
{
    public class BarberService
    {
        private readonly IBarberRepository _barberRepository;

        public BarberService(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }

        public async Task<List<Barber>> GetActiveAsync()
        {
            //Pido barberos activos
            var barbers = await _barberRepository.GetActiveAsync();

            //Devuelvo barberos activos
            return barbers;
        }

        public async Task<Barber> GetByIdAsync(int id)
        {
            //Pido Barberos
            var barber = await _barberRepository.GetByIdAsync(id);

            //Valido que exista
            if (barber == null)
                throw new Exception("barbero no encontrado.");

            //Valido que este activo
            if (!barber.IsActive)
                throw new Exception("barbero no activo.");

            //Devuelvo los barberos
            return barber;
        }
    }
}
