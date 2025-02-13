using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Entities.Services;

namespace App.Domain.Core.Entities.User
{
    public class Expert : UserBase
    {
        #region Properties
        public bool IsApproved { get; set; } = false;
        #endregion

        #region Navigation Properties
        public List<Service> Services { get; set; } = new List<Service>();
        public List<ServiceOffering> ServiceOfferings { get; set; } = new List<ServiceOffering>();
        #endregion
    }

}
