using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.BaseEntity
{
	public class Address
	{
		#region Prperties
		public int Id { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        #endregion

        #region Navigation Properties
        public City City { get; set; }
        #endregion
    }
}
