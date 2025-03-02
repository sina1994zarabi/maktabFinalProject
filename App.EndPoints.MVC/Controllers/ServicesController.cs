using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
