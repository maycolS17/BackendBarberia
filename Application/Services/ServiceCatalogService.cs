using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;

namespace Barberia.Backend.Application.Services
{
    public class ServiceCatalogService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceCatalogService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            //Busco el servicio
            var service = await _serviceRepository.GetByIdAsync(id);

            //Validar que exista
            if (service == null)
                throw new Exception("Servicio no encontrado.");

            //Validar que este activo
            if (!service.IsActive)
                throw new Exception("El servicio esta inactivo.");

            //devuelvo servicios
            return service;
        }

        public async Task<List<Service>> GetActiveAsync()
        {
            //Pido servicios activos
            var services = await _serviceRepository.GetActiveAsync();

            //devuelvo servicios activos
            return services;
        }
    }
}
