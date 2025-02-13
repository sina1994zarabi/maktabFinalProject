using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Services
{
    public class SubCategory
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string? Image { get; set; }
        #endregion

        #region Navigation Properties
        public Category Category { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        #endregion
    }

}
