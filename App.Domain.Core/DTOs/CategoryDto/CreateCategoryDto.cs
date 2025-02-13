using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.CategoryDto
{
	public class CreateCategoryDto
	{
        public string Title { get; set; }
        public string? ImagePath { get; set; }
    }
}
