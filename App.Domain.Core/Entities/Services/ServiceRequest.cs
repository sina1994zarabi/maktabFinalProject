using App.Domain.Core.Entities.BaseEntity;
using App.Domain.Core.Entities.User;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Services
{
    public class ServiceRequest
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ServiceId { get; set; }
        public int ClientId  { get; set; }
        public DateTime BookingDate { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.AwaitingOffers;
        public bool IsCompleted { get; set; } = false;
        #endregion


        #region Navigation Properties
        public Service Service { get; set; }
        public Client Client { get; set; }
        public List<ServiceOffering> ServiceOfferings { get; set; } = new List<ServiceOffering>();
        public List<Image> Images { get; set; }
        #endregion
    }
}
