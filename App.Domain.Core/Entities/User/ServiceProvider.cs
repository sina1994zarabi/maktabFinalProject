using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Entities.Services;

namespace App.Domain.Core.Entities.User
{
    public class ServiceProvider : UserBase
    {
        #region Properties
        public bool IsApproved { get; set; }
        public int AccountBalance { get; set; }
        #endregion

        #region Navigation Properties
        public List<Service> Skills { get; set; }
        public List<ServiceOffering> ServiceOfferings { get; set; }
        #endregion
    }

}
