using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.Client
{
	public class UpdateClientDto
	{
        public int Id { get; set; }
		public string FullName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string? ImagePath { get; set; }
    }
}
