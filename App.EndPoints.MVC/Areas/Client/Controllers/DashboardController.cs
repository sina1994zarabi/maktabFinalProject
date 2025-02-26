using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Client.Controllers
{
    [Area("Client")]
    public class DashboardController : Controller
    {
        public IActionResult Index(string username)
        {
            ViewData["Username"] = username;
            return View();
        }
    }
}
