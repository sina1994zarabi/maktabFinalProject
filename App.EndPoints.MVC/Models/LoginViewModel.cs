using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.Models
{
	public class LoginViewModel
	{
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "وارد کردن این فیلد اجباری است")]
        public string Username { get; set; }
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "وارد کردن رمز عیور اجباریست")]
		[StringLength(16,MinimumLength =8,ErrorMessage = "رمز عبور باید بین 8 تا 16  کاراکتر باشد")]
		public string Password { get; set; }
    }
}
