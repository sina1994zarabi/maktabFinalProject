using App.Domain.Core.DTOs.CategoryDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppService
{
    public interface ICategoryAppService
    {
        Task Create(CreateCategoryDto createCategoryDto,CancellationToken cancellationToken);
        Task<Category> GetById(int id, CancellationToken cancellationToken);
        Task<GetCategoryDto> GetCategoryDtoById(int id, CancellationToken cancellationToken);
        Task<List<Category>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(UpdateCategoryDto updateCategoryDto, CancellationToken cancellationToken);
    }
}
