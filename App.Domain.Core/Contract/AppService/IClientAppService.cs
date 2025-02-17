using App.Domain.Core.DTOs.ClientDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppService
{
    public interface IClientAppService
    {
        Task Create(CreateClientDto createClientDto,CancellationToken cancellationToken);
        Task<Client> GetById(int id, CancellationToken cancellationToken);
        Task<List<Client>> GetAll(CancellationToken cancellationToken);
        Task<Client> GetClientInfo(int id, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(UpdateClientDto updateClientDto, CancellationToken);
    }
}
