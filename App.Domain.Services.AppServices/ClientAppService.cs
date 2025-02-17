using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.ClientDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppServices
{
    public class ClientAppService : IClientAppService
    {
        private readonly IClientService _clientService;

        public ClientAppService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task Create(CreateClientDto createClientDto, CancellationToken cancellationToken)
        {
            await _clientService.Add(createClientDto,cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _clientService.Delete(id,cancellationToken);
        }

        public async Task<List<Client>> GetAll(CancellationToken cancellationToken)
        {
            return await _clientService.GetAll(cancellationToken);
        }

        public async Task<Client> GetById(int id, CancellationToken cancellationToken)
        {
            return await _clientService.Get(id,cancellationToken);
        }

        public Task<Client> GetClientInfo(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UpdateClientDto updateClientDto, CancellationToken cancellation)
        {
            await _clientService.Update(updateClientDto,cancellation);
        }
    }
}
