using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.CategoryDto
{
	public class CreateCategoryDto
	{
        [Required(ErrorMessage ="این فیلد نمی تواند خالی باشد")]
        public string Title { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public string? ImagePath { get; set; }
    }
}
