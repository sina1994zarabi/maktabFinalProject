using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.ServiceDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }


        public async Task Add(CreateServiceDto service, CancellationToken cancellationToken)
        {
            await _serviceRepository.Add(service, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _serviceRepository.Delete(id, cancellationToken);
        }

        public async Task<Service> Get(int id, CancellationToken cancellationToken)
        {
            return await _serviceRepository.Get(id, cancellationToken);
        }

        public async Task<List<Service>> GetAll(CancellationToken cancellationToken)
        {
            return await _serviceRepository.GetAll(cancellationToken);
        }

        public async Task Update(UpdateServiceDto service, CancellationToken cancellationToken)
        {
            await _serviceRepository.Update(service, cancellationToken);
        }
    }
}
