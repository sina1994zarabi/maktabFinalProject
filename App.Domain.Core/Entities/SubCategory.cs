using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
	public class Subcategory
	{
		#region Properties
		public int Id { get; set; }
		public string Name { get; set; }
		public int CategoryId { get; set; }
		#endregion

		#region Navigation Properties
		public Category Category { get; set; }
		public ICollection<Service> Services { get; set; }
		#endregion
	}

}
