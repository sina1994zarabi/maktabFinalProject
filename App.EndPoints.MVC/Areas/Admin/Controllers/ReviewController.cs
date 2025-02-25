using App.Domain.Core.Contract.AppService;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ReviewController : Controller
	{

		private readonly IReviewAppService _reviewAppService;

        public ReviewController(IReviewAppService reviewAppService)
        {
			_reviewAppService = reviewAppService;
        }

        public async Task<IActionResult> Index()
		{
			var model = await _reviewAppService.GetAll(default);
			return View(model);
		}

		
		public async Task<IActionResult> ConfirmOrReject(int id)
		{
			await _reviewAppService.ConfirmOrRejectReview(id, default);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _reviewAppService.Delete(id,default);
			return RedirectToAction("Index");
		}

	}
}
