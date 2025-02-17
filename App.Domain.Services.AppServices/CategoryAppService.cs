using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.CategoryDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppServices
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;


        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Create(CreateCategoryDto createCategoryDto, CancellationToken cancellationToken)
        {
            await _categoryService.Create(createCategoryDto,cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _categoryService.Delete(id,cancellationToken);
        }

        public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAll(cancellationToken);
        }

        public Task<Category> GetById(int id, CancellationToken cancellationToken)
        {
            return _categoryService.Get(id,cancellationToken);
        }

        public async Task Update(UpdateCategoryDto updateCategoryDto, CancellationToken cancellationToken)
        {
            await _categoryService.Upate(updateCategoryDto,cancellationToken);
        }
    }
}
