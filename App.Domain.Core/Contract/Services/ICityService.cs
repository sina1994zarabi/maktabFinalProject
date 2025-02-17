using App.Domain.Core.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface ICityService
    {
        Task Add(City city, CancellationToken cancellationToken);
        Task<City> Get(int id, CancellationToken cancellationToken);
        Task<List<City>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(City city, CancellationToken cancellationToken);
    }
}
