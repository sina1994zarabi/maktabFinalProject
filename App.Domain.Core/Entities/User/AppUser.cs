using App.Domain.Core.Entities.BaseEntity;
using App.Domain.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.User
{
    public class AppUser : IdentityUser<int>
    {
        #region Property
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        public decimal AccountBalance { get; set; }
        #endregion

        #region Navigation Properties
        public Admin? AdminProfile { get; set; }
        public Expert? ExpertProfile { get; set; }
        public Client? ClientProfile { get; set; }
        #endregion
    }
}
