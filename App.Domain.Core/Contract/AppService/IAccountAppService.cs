using App.Domain.Core.DTOs.AccountDto;
using App.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppService
{
    public interface IAccountAppService
    {
        Task<List<IdentityError>> Register(AccountRegisterDto accountRegisterDto);
        //Task<List<IdentityError>> AdminRegister(AccountAdminRegisterDto accountAdminRegisterDto);
        Task<bool> Login(AccountLoginDto accountLoginDto);
        Task<string> GetRedirectUrlForUser(string username);
        Task<IdentityResult> UpdateUserAsync(UpdateAccountDto updateDto);
        Task<IdentityResult> DeleteUserAsync(int id);
        Task Logout();
    }
}
