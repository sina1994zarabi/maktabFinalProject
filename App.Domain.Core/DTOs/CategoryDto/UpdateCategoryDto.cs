﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.CategoryDto
{
	public class UpdateCategoryDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string? ImagePath { get; set; }
    }
}
