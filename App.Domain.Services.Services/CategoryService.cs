using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.CategoryDto;
using App.Domain.Core.Entities.Services;

namespace App.Domain.Services.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryService)
        {
            _categoryRepository = categoryService;
        }

        public async Task Create(CreateCategoryDto createCategoryDto, CancellationToken cancellationToken)
        {
            await _categoryRepository.Add(createCategoryDto, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _categoryRepository.Delete(id, cancellationToken);
        }

        public async Task<Category> Get(int id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Get(id, cancellationToken);
        }

        public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll(cancellationToken);
        }

        public async Task Upate(UpdateCategoryDto updateCategoryDto, CancellationToken cancellationToken)
        {
            await _categoryRepository.Update(updateCategoryDto, cancellationToken);
        }
    }
}
