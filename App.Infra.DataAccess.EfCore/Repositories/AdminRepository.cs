using App.Domain.Core.Contract.Repository;
using App.Domain.Core.DTOs.AdminDto;
using App.Domain.Core.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task Add(CreateAdminDto createAdminDto, CancellationToken cancellationToken)
        {
            var newAdmin = new Admin
            {
                FullName = createAdminDto.FullName,
                Gender = createAdminDto.Gender
            };
            await _context.Admins.AddAsync(newAdmin);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var adminToRemove = await _context.Admins.FindAsync(id);
            if (adminToRemove != null)
            {
                _context.Admins.Remove(adminToRemove);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<Admin> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Admins.FindAsync(id,cancellationToken);
        }

        public async Task<List<Admin>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Admins.ToListAsync(cancellationToken);
        }

        public async Task Update(UpdateAdminDto updateAdminDto, CancellationToken cancellationToken)
        {
            var adminToEdit = await _context
                .Admins
                .Include(a => a.AppUser)
                .FirstOrDefaultAsync(a => a.Id ==updateAdminDto.Id,cancellationToken);

            if (adminToEdit != null)
            {
                adminToEdit.FullName = updateAdminDto.FullName;
                adminToEdit.AppUser.UserName = updateAdminDto.Username;
                adminToEdit.AppUser.Email = updateAdminDto.Email;
                adminToEdit.AppUser.PhoneNumber = updateAdminDto.PhoneNumber;
                await _context.SaveChangesAsync(cancellationToken);
            };
        }
    }
}
