using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.ServiceRequestDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppServices
{
    public class ServiceRequestAppService : IServiceRequestAppService
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ServiceRequestAppService(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        public async Task Create(CreateServiceRequestDto createServiceRequestDto, CancellationToken cancellationToken)
        {
            await _serviceRequestService.Add(createServiceRequestDto,cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _serviceRequestService.Delete(id,cancellationToken);
        }

        public async Task<List<ServiceRequest>> GetAll(CancellationToken cancellationToken)
        {
            return await _serviceRequestService.GetAll(cancellationToken);
        }

        public async Task<ServiceRequest> GetById(int id, CancellationToken CancellationToken)
        {
            return await _serviceRequestService.Get(id,CancellationToken);
        }

        public Task Update(ServiceRequest serviceRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
