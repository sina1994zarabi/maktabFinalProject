using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.ClientDto;
using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.Entities.User;
using App.EndPoints.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly IClientAppService _clientAppService;
        private readonly IExpertAppService _expertAppService;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IClientAppService clientAppService,
                              IExpertAppService expertAppService,
                              UserManager<AppUser> userManager)
        {
            _clientAppService = clientAppService;
            _expertAppService = expertAppService;
            _userManager = userManager;
        }

        public IActionResult Index() { return View(); }
        
        public async Task<IActionResult> Clients()
        {
            var clients = await _clientAppService.GetAll(default);
            return View(clients);
        }

        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
                FullName = model.FullName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user,"Client");
                var newCLient = new CreateClientDto
                {
                    FullName = model.FullName,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    AppUserId = user.Id
                };
                await _clientAppService.Create(newCLient, default);
                return RedirectToAction("Clients");
            }
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
            return View(model);
        } 


        public async Task<IActionResult> ClientDetails(int id)
        {
            var client = await _clientAppService.GetClientInfo(id, default);
            return View(client);
        }


        
        public async Task<IActionResult> DeleteClient(int id)
        {
            var clientToDelete = await _clientAppService.GetById(id, default);
            var user = await _userManager.FindByIdAsync(clientToDelete.AppUserId.ToString());
            await _userManager.DeleteAsync(user);
            await _clientAppService.Delete(id, default);
            return RedirectToAction("Clients");
        }

        public async Task<IActionResult> Experts()
        {
            var experts = await _expertAppService.GetAll(default);
            return View(experts);
        }

        public IActionResult CreateExpert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpert(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
                FullName = model.FullName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Expert");
                var newExpert = new CreateExpertDto
                {
                    FullName = model.FullName,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    AppUserId = user.Id
                };
                await _expertAppService.Create(newExpert, default);
                return RedirectToAction("Experts");
            }
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
            return View(model);
        }

        public async Task<IActionResult> ExpertDetails(int id)
        {
            var expert = await _expertAppService.GetExpertInfo(id, default);
            return View(expert);
        }


        public async Task<IActionResult> DeleteExpert(int id)
        {
            var expertToDelete = await _expertAppService.GetById(id, default);
            var user = await _userManager.FindByIdAsync(expertToDelete.AppUserId.ToString());
            await _userManager.DeleteAsync(user);
            await _expertAppService.Delete(id, default);
            return RedirectToAction("Experts");
        }
    }
}
