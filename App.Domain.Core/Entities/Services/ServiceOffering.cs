using App.Domain.Core.Entities.User;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Services
{
    public class ServiceOffering
    {
        #region Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public int ServiceProviderId { get; set; }
        public int ServiceRequestId { get; set; }
        public DateTime CreatedAt { get; set; }
        #endregion

        #region Navigation Properties
        public ServiceProvider ServiceProvider { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
        public List<Review> Reviews { get; set; }
        #endregion
    }
}
