using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
	public class Category
	{
		#region Properties
		public int Id { get; set; }
		public string Name { get; set; }
		#endregion

		#region Navigation Property
		public List<Subcategory> Subcategories { get; set; }
		#endregion
	}

}
