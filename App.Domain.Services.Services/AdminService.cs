using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.AdminDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;


        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task Add(CreateAdminDto createAdminDto, CancellationToken cancellationToken)
        {
            await _adminRepository.Add(createAdminDto,cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _adminRepository.Delete(id,cancellationToken);
        }

        public async Task<Admin> Get(int id, CancellationToken cancellationToken)
        {
            return await _adminRepository.Get(id,cancellationToken);
        }

        public async Task<List<Admin>> GetAll(CancellationToken cancellationToken)
        {
            return await _adminRepository.GetAll(cancellationToken);
        }

        public async Task Update(UpdateAdminDto updateAdminDto, CancellationToken cancellationToken)
        {
            await _adminRepository.Update(updateAdminDto,cancellationToken);
        }
    }
}
