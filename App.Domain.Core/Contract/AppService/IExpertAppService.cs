﻿using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Http;
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
        Task<Expert> GetById(int id, CancellationToken cancellationToken);
        Task<List<Expert>> GetAll(CancellationToken cancellationToken);
        Task<Expert> GetExpertInfo(int id, CancellationToken cancellation);
        Task<Expert> GetExpertByUserId(int userId, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(UpdateExpertDto updateExpertDto, CancellationToken cancellationToken,IFormFile Image);
        Task ChangeStatus(int id, CancellationToken cancellationToken);
    }
}
