using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
	public class ServiceProvider : UserBase
	{
		#region Properties
        public bool IsApproved { get; set; }
        #endregion

        #region Navigation Properties
        public List<Service> Services { get; set; }
		#endregion
	}

}
