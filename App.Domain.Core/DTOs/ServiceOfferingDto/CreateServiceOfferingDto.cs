using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.ServiceOfferingDto
{
    public class CreateServiceOfferingDto
    {
        public string Description { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.PendingClientConfirmation;
        public int ExpertId { get; set; }
        public int ServiceRequestId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
