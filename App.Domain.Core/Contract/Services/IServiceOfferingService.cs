using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IServiceOfferingService
    {
        Task Add(ServiceOffering serviceOffering, CancellationToken cancellationToken);
        Task<ServiceOffering> Get(int id, CancellationToken cancellationToken);
        Task<List<ServiceOffering>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(ServiceOffering serviceOffering, CancellationToken cancellationToken);
    }
}
