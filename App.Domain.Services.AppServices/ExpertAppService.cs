﻿using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppServices
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _expertService;

        public ExpertAppService(IExpertService expertService)
        {
            _expertService = expertService;
        }

        public async Task Create(CreateExpertDto createExpertDto, CancellationToken cancellationToken)
        {
            await _expertService.Add(createExpertDto,cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _expertService.Delete(id,cancellationToken);
        }

        public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
        {
            return await _expertService.GetAll(cancellationToken);
        }

        public Task<Expert> GetExpertInfo(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UpdateExpertDto updateExpertDto, CancellationToken cancellationToken)
        {
            await _expertService.Update(updateExpertDto,cancellationToken);
        }
    }
}
