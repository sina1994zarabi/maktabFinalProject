﻿using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs.Client
{
	public class CreateClientDto
	{
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
    }
}
