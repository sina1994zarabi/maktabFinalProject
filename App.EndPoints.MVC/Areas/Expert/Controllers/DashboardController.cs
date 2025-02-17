using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Expert.Controllers
{
    [Area("Expert")]
    public class DashboardController : Controller
    {
        public IActionResult Index(string username)
        {
            ViewData["Username"] = username;
            return View();
        }

    }
}
