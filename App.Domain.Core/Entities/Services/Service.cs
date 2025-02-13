using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Services
{
    public class Service
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // could implement a range price
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        #endregion

        #region Navgation Property
        public SubCategory Subcategory { get; set; }
        public List<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
        public List<Expert> Experts { get; set; } = new List<Expert>();
        #endregion
    }
}
