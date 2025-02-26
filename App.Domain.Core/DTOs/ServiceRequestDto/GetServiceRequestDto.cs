using App.Domain.Core.Entities.BaseEntity;
using App.Domain.Core.Entities.Services;
using App.Domain.Core.Entities.User;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Domain.Core.DTOs.ServiceRequestDto
{
    public class GetServiceRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public Client Client { get; set; }
        public List<ServiceOffering>? ServiceOfferings { get; set; }
        public Service Service { get; set; }
        public List<Image>? Images { get; set; }
    }
}
