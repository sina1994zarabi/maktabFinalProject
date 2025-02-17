using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.SubCategoryDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task Add(CreateSubCategoryDto subcategory, CancellationToken cancellationToken)
        {
            await _subCategoryRepository.Add(subcategory, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _subCategoryRepository.Delete(id, cancellationToken);
        }

        public async Task<SubCategory> Get(int id, CancellationToken cancellationToken)
        {
            return await _subCategoryRepository.Get(id, cancellationToken);
        }

        public async Task<List<SubCategory>> GetAll(CancellationToken cancellationToken)
        {
            return await _subCategoryRepository.GetAll(cancellationToken);
        }

        public async Task Update(UpdateSubCategoryDto subcategory, CancellationToken cancellationToken)
        {
            await _subCategoryRepository.Update(subcategory, cancellationToken);
        }
    }
}
