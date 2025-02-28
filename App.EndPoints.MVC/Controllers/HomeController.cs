using App.Domain.Core.Contract.AppService;
using App.EndPoints.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICategoryAppService _categoryAppService;

		public HomeController(ILogger<HomeController> logger,
			ICategoryAppService categoryAppService)
		{
			_logger = logger;
			_categoryAppService = categoryAppService;
		}

		public async Task<IActionResult> Index()
		{
			var categories = await _categoryAppService.GetAll(default);
			return View(categories);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}