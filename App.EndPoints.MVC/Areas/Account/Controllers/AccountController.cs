using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.AccountDto;
using App.Domain.Core.DTOs.ClientDto;
using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.Entities.User;
using App.EndPoints.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Serilog;

namespace App.EndPoints.MVC.Areas.Account.Controllers
{
    [Area("Account")]
    public class AccountController : Controller
    {

        private readonly IAccountAppService _accountAppService;
        private readonly IClientAppService _clientAppService;
        private readonly IExpertAppService _expertAppService;


        public AccountController(IAccountAppService accountAppService,
                                 IClientAppService clientAppService,
                                 IExpertAppService expertAppService
                                 )
        {
            _accountAppService = accountAppService;
            _clientAppService = clientAppService;
            _expertAppService = expertAppService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var result = await _accountAppService.Login(model);

            if (result)
            {
                string redirectUrl = await _accountAppService.GetRedirectUrlForUser(model.Username);
                return Redirect(redirectUrl);
            }
            ModelState.AddModelError("", "ورود ناموفق");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new AccountRegisterDto());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _accountAppService.Register(model);
            if (result.Count == 0)
                return RedirectToAction("Login");
            foreach (var error in result)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }


        public async Task<IActionResult> LogOut()
        {
            await _accountAppService.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}
