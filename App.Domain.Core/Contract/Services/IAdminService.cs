using App.Domain.Core.DTOs.AdminDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IAdminService 
    {
        Task Add(CreateAdminDto createAdminDto, CancellationToken cancellationToken);
        Task<Admin> Get(int id, CancellationToken cancellationToken);
        Task<List<Admin>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(UpdateAdminDto updateAdminDto, CancellationToken cancellationToken);
    }
}
