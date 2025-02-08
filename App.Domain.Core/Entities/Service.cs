using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
	public class Service
	{
		#region Properties
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int ServiceProviderId { get; set; }
        public int SubCategoryId { get; set; }
        #endregion

        #region Navgation Property
        public Subcategory Subcategory { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
		public List<Booking> Bookings { get; set; }
		#endregion 
	}
}
