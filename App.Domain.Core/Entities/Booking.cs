using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
	public class Booking
	{
		#region Properties
		public int Id { get; set; }
		public int ServiceId { get; set; } 
		public int ClientId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime BookingDate { get; set; }
		public DateTime ServiceDate { get; set; }
		public StatusEnum Status { get; set; }
		public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;
		#endregion


		#region Navigation Properties
		public Service Service { get; set; }
		public Client Client { get; set; }
		#endregion
	}
}
