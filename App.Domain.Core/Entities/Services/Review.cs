using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Services
{
	public class Review
	{
		#region Properties
		public int Id { get; set; }
        // range From 1-5
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ClientId { get; set; }
        public int ServiceOfferingId { get; set; }
        public bool IsApproved { get; set; }
        #endregion

        #region Navigation Properties
        public Client Client { get; set; }
        public ServiceOffering ServiceOffering { get; set; }
		#endregion
	}
}
