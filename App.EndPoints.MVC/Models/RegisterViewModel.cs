﻿using App.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.Models
{
	public class RegisterViewModel
	{
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
		public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "رمز عبور یکی نیست")]
        public string ConfirmedPassword { get; set; }
        public string Role { get; set; }
        public Gender Gender { get; set; }
    }
}
