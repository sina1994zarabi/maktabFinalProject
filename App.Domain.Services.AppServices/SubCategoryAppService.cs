using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.SubCategoryDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppServices
{
    public class SubCategoryAppService : ISubCategoryAppService
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryAppService(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        public async Task Create(CreateSubCategoryDto createSubCategoryDto, CancellationToken cancellationToken)
        {
            await _subCategoryService.Add(createSubCategoryDto,cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _subCategoryService.Delete(id,cancellationToken);
        }

        public async Task<List<SubCategory>> GetAll(CancellationToken cancellationToken)
        {
            return await _subCategoryService.GetAll(cancellationToken);
        }

        public async Task<SubCategory> GetById(int id, CancellationToken cancellationToken)
        {
            return await _subCategoryService.Get(id,cancellationToken);
        }

        public async Task Update(UpdateSubCategoryDto updateSubCategoryDto, CancellationToken cancellationToken)
        {
            await _subCategoryService.Update(updateSubCategoryDto,cancellationToken);
        }
    }
}
