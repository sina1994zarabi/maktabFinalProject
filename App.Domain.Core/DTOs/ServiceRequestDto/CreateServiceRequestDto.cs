using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.ServiceRequestDto
{
    public class CreateServiceRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
