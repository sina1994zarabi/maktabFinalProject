using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.SubCategoryDto
{
	public class UpdateSubCategoryDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string? ImagePath { get; set; }
    }
}
