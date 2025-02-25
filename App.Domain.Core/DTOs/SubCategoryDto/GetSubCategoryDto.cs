using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.SubCategoryDto
{
    public class GetSubCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
