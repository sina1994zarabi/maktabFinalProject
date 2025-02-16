﻿using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IServiceRequestService
    {
        Task Add(ServiceRequest serviceRequest, CancellationToken cancellationToken);
        Task<ServiceRequest> Get(int id, CancellationToken cancellationToken);
        Task<List<ServiceRequest>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(ServiceRequest serviceRequest, CancellationToken cancellationToken);
    }
}
