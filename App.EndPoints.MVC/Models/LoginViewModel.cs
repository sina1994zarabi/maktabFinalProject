using Microsoft.Build.Framework;

namespace App.EndPoints.MVC.Models
{
	public class LoginViewModel
	{
		[Required]
        public string Username { get; set; }
		[Required]
		public string Password { get; set; }
    }
}
