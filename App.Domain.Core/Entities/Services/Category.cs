using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Services
{
    public class Category
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        #endregion

        #region Navigation Property
        public List<SubCategory> Subcategories { get; set; } = new List<SubCategory>();
        #endregion
    }
}
