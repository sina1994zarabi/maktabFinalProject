using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.CategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
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
            await _categoryAppService.Create(model, default);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryAppService.GetById(id, default);
            if (category == null) { return NotFound();}
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _categoryAppService.Update(model,default);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryAppService.Delete(id,default);
            return RedirectToAction("Index");
        }
    }
}
