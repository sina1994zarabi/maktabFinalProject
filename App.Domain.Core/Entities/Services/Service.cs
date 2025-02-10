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
        public int Price { get; set; }
        public int SubCategoryId { get; set; }
        #endregion

        #region Navgation Property
        public Subcategory Subcategory { get; set; }
        public List<ServiceRequest> ServiceRequests { get; set; }
        public List<ServiceProvider> ServiceProviders { get; set; }
        #endregion
    }
}
