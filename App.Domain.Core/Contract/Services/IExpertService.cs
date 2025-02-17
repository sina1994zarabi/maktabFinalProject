﻿using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IExpertService
    {
        Task Add(CreateExpertDto expert, CancellationToken cancellation);
        Task<Expert> Get(int id, CancellationToken cancellation);
        Task<List<Expert>> GetAll(CancellationToken cancellation);
        Task Delete(int id, CancellationToken cancellation);
        Task Update(UpdateExpertDto expert, CancellationToken cancellation);
    }
}
