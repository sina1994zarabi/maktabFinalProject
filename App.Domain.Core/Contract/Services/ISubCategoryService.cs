using App.Domain.Core.DTOs.SubCategoryDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface ISubCategoryService
    {
        Task Add(CreateSubCategoryDto subcategory, CancellationToken cancellationToken);
        Task<SubCategory> Get(int id, CancellationToken cancellationToken);
        Task<List<SubCategory>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(UpdateSubCategoryDto subcategory, CancellationToken cancellationToken);
    }
}
