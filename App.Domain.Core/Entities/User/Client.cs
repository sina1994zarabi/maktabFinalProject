using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Entities.Services;

namespace App.Domain.Core.Entities.User
{
    public class Client : UserBase
    {
        #region
        public int AccountBalance { get; set; }
        #endregion

        #region Navigation properties
        public List<ServiceRequest> ServiceRequests { get; set; }
        public List<Review> Reviews { get; set; }
        #endregion
    }
}
