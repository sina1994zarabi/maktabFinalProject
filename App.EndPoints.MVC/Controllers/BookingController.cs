using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
