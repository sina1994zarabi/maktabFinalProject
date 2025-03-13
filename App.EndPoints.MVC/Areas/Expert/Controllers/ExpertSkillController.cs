using App.Domain.Core.Contract.AppService;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Expert.Controllers
{
    [Area("Expert")]
    public class ExpertSkillController : Controller
    {

        private readonly IExpertAppService _expertAppService;

        public ExpertSkillController(IExpertAppService expertAppService)
        {
            _expertAppService = expertAppService;
        }

        public IActionResult Index()
        {
            return View();
        }





    }
}
