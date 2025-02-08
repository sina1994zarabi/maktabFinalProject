using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
	public class Client : UserBase
	{
		#region Navigation properties
		public List<Booking> Bookings { get; set; }
		#endregion
	}
}
