using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.ServiceDto
{
	public class CreateServiceDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int SubCategoryId { get; set; }
	}
}
