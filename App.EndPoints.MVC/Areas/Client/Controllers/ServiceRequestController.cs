﻿using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.ServiceRequestDto;
using App.Domain.Core.Entities.Services;
using App.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace App.EndPoints.MVC.Areas.Client.Controllers
{
	[Area("Client")]
	public class ServiceRequestController : Controller
	{

		private readonly IClientAppService _clientAppService;
		private readonly IServiceAppService _serviceAppService;
		private readonly IServiceRequestAppService _requestAppService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMemoryCache _memoryCache;

		public ServiceRequestController(IClientAppService clientAppService,
			UserManager<AppUser> userManager,
			IServiceAppService serviceAppService,
			IServiceRequestAppService serviceRequestAppService,
			IMemoryCache memoryCache)
		{
			_clientAppService = clientAppService;
			_userManager = userManager;
			_serviceAppService = serviceAppService;
			_requestAppService = serviceRequestAppService;
			_memoryCache = memoryCache;
		}

		public async Task<IActionResult> ViewServiceRequests()
		{
			var user = await _userManager.GetUserAsync(User);
			var client = await _clientAppService.GetClientByUserId(user.Id, default);
			var model = await _clientAppService.GetServiceRequests(client.Id, default);
			ViewBag.Message = TempData["Message"] as string;
			return View(model);
		}

		public async Task<IActionResult> SubmitRequest(int id)
		{
			var service = await _serviceAppService.GetById(id, default);
			ViewBag.Service = service;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SubmitRequest(CreateServiceRequestDto model)
		{
			if (!ModelState.IsValid)
				return View(model);
            var user = await _userManager.GetUserAsync(User);
            var client = await _clientAppService.GetClientByUserId(user.Id, default);
			model.ClientId = client.Id;
            await _clientAppService.SubmitServiceRequest(model, default);
			TempData["Message"] = "سفارش با موفقیت ثبت شد";
			return RedirectToAction("ViewServiceRequests");
		}
	}
}
