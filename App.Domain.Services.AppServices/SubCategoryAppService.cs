using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.SubCategoryDto;
using App.Domain.Core.Entities.Services;
using Microsoft.AspNetCore.Http;
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
        private readonly IUtilityService _utilityService;

        public SubCategoryAppService(ISubCategoryService subCategoryService, IUtilityService utilityService)
        {
            _subCategoryService = subCategoryService;
            _utilityService = utilityService;
        }

        public async Task Create(CreateSubCategoryDto createSubCategoryDto, CancellationToken cancellationToken,IFormFile image)
        {
            var imagePath = await _utilityService.UploadImage(image);
            createSubCategoryDto.ImagePath = imagePath;
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

        public async Task<List<SubCategory>> GetAllSubCategoriesByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            var allSubs = await _subCategoryService.GetAll(cancellationToken);
            return allSubs.Where(x => x.CategoryId == categoryId).ToList();
        }

        public async Task<SubCategory> GetById(int id, CancellationToken cancellationToken)
        {
            return await _subCategoryService.Get(id,cancellationToken);
        }

        public async Task<GetSubCategoryDto> GetSubCategoryDtoById(int id, CancellationToken cancellationToken)
        {
            var subCategory = await _subCategoryService.Get(id,cancellationToken);
            var getSubCategoryDto = new GetSubCategoryDto
            {
                Id = subCategory.Id,
                Title = subCategory.Title,
                CategoryId = subCategory.CategoryId,
                ImagePath = subCategory.ImagePath
            };
            return getSubCategoryDto;
        }

        public async Task Update(UpdateSubCategoryDto updateSubCategoryDto, CancellationToken cancellationToken,IFormFile image)
        {
            var imagePath = await _utilityService.UploadImage(image);
            updateSubCategoryDto.ImagePath = imagePath;
            await _subCategoryService.Update(updateSubCategoryDto,cancellationToken);
        }
    }
}
