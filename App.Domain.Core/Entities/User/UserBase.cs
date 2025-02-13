using App.Domain.Core.Entities.BaseEntity;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.User
{
    public abstract class UserBase
    {
		#region Property
		public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        //public string Password { get; set; }
        public int? AddressId { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
        public string? ProfilePicture { get; set; }
        public decimal AccountBalance { get; set; }
        #endregion

        #region Navigation Properties
        public Address Address { get; set; }
        #endregion
    }
}
