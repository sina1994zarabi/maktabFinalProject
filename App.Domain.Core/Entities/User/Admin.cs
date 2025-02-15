using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.User
{
	public class Admin
	{
        #region Properties
        public int Id { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public int AppUserId { get; set; }
        #endregion

        #region Navigation Properties
        public AppUser AppUser { get; set; }
        #endregion
    }
}
