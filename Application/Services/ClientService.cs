using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;

namespace Barberia.Backend.Application.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            var customer = await _clientRepository.CreateAsync(client);

            return customer;
        }

        public async Task<Client?> GetByPhoneAsync(string phone)
        {
            var client = await _clientRepository.GetByPhoneAsync(phone);

            return client;
        }

        //de parametros obtenemos todo lo de cliente y creamos un nuevo metodo para buscar o crear
        public async Task<Client> GetOrCreateAsync(Client client)
        {
            //creo variable para validar cliente existente donde busco por telefono
            var existingClient = await _clientRepository.GetByPhoneAsync(client.Phone);

            //si no es nulo, devolvemos el existente
            if (existingClient != null)
                return existingClient;

            //creamos variable para nuevo cliente
            var newClient = await _clientRepository.CreateAsync(client);

            //devuelvo el cliente creado
            return newClient;
        }
    }
}
