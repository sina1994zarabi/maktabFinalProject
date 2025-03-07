using App.Domain.Core.DTOs.ServiceDto;
using App.Domain.Core.Entities.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IServiceService
    {
        Task Add(CreateServiceDto service, CancellationToken cancellationToken);
        Task<Service> Get(int id, CancellationToken cancellationToken);
        Task<List<Service>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(UpdateServiceDto service, CancellationToken cancellationToken);
    }
}
