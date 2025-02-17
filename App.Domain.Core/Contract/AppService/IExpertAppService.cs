using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppService
{
    public interface IExpertAppService
    {
        Task Create(CreateExpertDto createExpertDto,CancellationToken cancellationToken);
        Task<Expert> GetExpertInfo(int id, CancellationToken cancellationToken);
        Task<List<Expert>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(UpdateExpertDto updateExpertDto, CancellationToken cancellationToken);
    }
}
