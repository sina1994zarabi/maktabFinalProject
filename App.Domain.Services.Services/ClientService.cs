using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.ClientDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Add(CreateClientDto client, CancellationToken cancellation)
        {
            await _clientRepository.Add(client, cancellation);
        }

        public async Task Delete(int id, CancellationToken cancellation)
        {
            await _clientRepository.Delete(id, cancellation);
        }

        public async Task<Client> Get(int id, CancellationToken cancellation)
        {
            return await _clientRepository.Get(id, cancellation);
        }

        public async Task<List<Client>> GetAll(CancellationToken cancellation)
        {
            return await _clientRepository.GetAll(cancellation);
        }

        public async Task Update(UpdateClientDto client, CancellationToken cancellation)
        {
            await _clientRepository.Update(client, cancellation);
        }
    }
}
