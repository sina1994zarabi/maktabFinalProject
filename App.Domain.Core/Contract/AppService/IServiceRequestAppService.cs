﻿using App.Domain.Core.DTOs.ServiceRequestDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppService
{
    public interface IServiceRequestAppService
    {
        Task Create(CreateServiceRequestDto createServiceRequestDto, CancellationToken cancellationToken);
        Task<ServiceRequest> GetById(int id, CancellationToken CancellationToken);
        Task<List<ServiceRequest>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(ServiceRequest serviceRequest, CancellationToken cancellationToken);
    }
}
