using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Entities.BaseEntity;
using App.Domain.Core.Entities.Services;

namespace App.Domain.Core.Entities.User
{
    public class Client : UserBase
    {
        #region Properties
        
        #endregion

        #region Navigation properties
        public List<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
        #endregion
    }
}
