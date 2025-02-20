using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Contract.Services
{
    public interface IUtilityService
    {
        Task<string> UploadImage(IFormFile image);
    }
}
