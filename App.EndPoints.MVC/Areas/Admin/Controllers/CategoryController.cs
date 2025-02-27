using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using NuGet.Packaging.Signing;

namespace App.EndPoints.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly ILogger<CategoryController> _logger;


        public CategoryController(ICategoryAppService categoryAppService, ILogger<CategoryController> logger)
        {
            _categoryAppService = categoryAppService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryAppService.GetAll(default);
            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryAppService.GetById(id, default);
            if (category == null) { return NotFound(); }
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _categoryAppService.Create(model,default, model.Image);
            var timeStamp = DateTime.Now;
            _logger.LogWarning("[{Timestamp}] اضافه شدن دسته بندی اصلی جدید: {Title}", timeStamp, model.Title);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryAppService.GetCategoryDtoById(id, default);   
            if (category == null) { return NotFound();}
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _categoryAppService.Update(model,default,model.Image);
            var timeStamp = DateTime.Now;
            _logger.LogWarning("[{Timestamp}] ویرایش دسته بندی: {Title}", timeStamp, model.Title);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryAppService.Delete(id,default);
            var timeStamp = DateTime.Now;
            _logger.LogWarning("[{Timestamp}] پاک شدن دسته بندی: {Id}", timeStamp, id);
            return RedirectToAction("Index");
        }
    }
}
