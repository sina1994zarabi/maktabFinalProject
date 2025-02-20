using App.Domain.Core.Contract.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class UtilityService : IUtilityService
    {
        public async Task<string> UploadImage(IFormFile image)
        {
            string filePath;
            string fileName;
            if (image != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                filePath = Path.Combine("wwwroot/uploads", fileName);
                try
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await image.CopyToAsync(stream);
                    }
                }
                catch
                {
                    throw new Exception("Upload files operation failed");
                }
                return $"/uploads/{fileName}";
            }
            else
                fileName = "";

            return fileName;
        }
    }
}
