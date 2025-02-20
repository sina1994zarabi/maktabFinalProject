using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.CategoryDto;
using App.Domain.Core.Entities.Services;
using Microsoft.AspNetCore.Http;
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
        private readonly IUtilityService _utilityService;

        public CategoryAppService(ICategoryService categoryService, IUtilityService utilityService)
        {
            _categoryService = categoryService;
            _utilityService = utilityService;

        }

        public async Task Create(CreateCategoryDto createCategoryDto, CancellationToken cancellationToken,IFormFile image)
        {
            var imagePath = await _utilityService.UploadImage(image);
            createCategoryDto.ImagePath = imagePath;
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

        public async Task<GetCategoryDto> GetCategoryDtoById(int id, CancellationToken cancellationToken)
        {
            var category = await _categoryService.Get(id,cancellationToken);
            var getCategoryDto = new GetCategoryDto
            {
                Id = category.Id,
                Title = category.Title,
                ImagePath = category.Image
            };
            return getCategoryDto;
        }

        public async Task Update(UpdateCategoryDto updateCategoryDto, CancellationToken cancellationToken,IFormFile image)
        {
            var imagePath = await _utilityService.UploadImage(image);
            updateCategoryDto.ImagePath = imagePath;
            await _categoryService.Upate(updateCategoryDto,cancellationToken);
        }
    }
}
