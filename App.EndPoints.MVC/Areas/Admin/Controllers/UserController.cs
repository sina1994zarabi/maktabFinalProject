using App.Domain.Core.Contract.AppService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly IClientAppService _clientAppService;
        private readonly IExpertAppService _expertAppService;

        public UserController(IClientAppService clientAppService,
                              IExpertAppService expertAppService)
        {
            _clientAppService = clientAppService;
            _expertAppService = expertAppService;

        }

        public IActionResult Index() { return View(); }
        
        public async Task<IActionResult> Clients()
        {
            var clients = await _clientAppService.GetAll(default);
            return View(clients);
        }

        public async Task<IActionResult> ClientDetails(int id)
        {
            var client = await _clientAppService.GetClientInfo(id, default);
            return View(client);
        }

        public async Task<IActionResult> Experts()
        {
            var experts = await _expertAppService.GetAll(default);
            return View(experts);
        }

        public async Task<IActionResult> ExpertDetails(int id)
        {
            var expert = await _expertAppService.GetExpertInfo(id, default);
            return View(expert);
        }
    }
}
