using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Entities.BaseEntity;
using App.Domain.Core.Entities.Services;
using App.Domain.Core.Enums;

namespace App.Domain.Core.Entities.User
{
    public class Expert 
    {
        #region Properties
        public int Id { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int AppUserId { get; set; }
        public bool IsApproved { get; set; } = false;
        #endregion

        #region Navigation Properties
        public AppUser AppUser { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        public List<ServiceOffering> ServiceOfferings { get; set; } = new List<ServiceOffering>();
        #endregion
    }

}
