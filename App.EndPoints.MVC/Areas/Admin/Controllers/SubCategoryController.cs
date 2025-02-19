using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.SubCategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {

        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly ICategoryAppService _categoryAppService;

        public SubCategoryController(ISubCategoryAppService subCategoryAppService,
            ICategoryAppService categoryAppService)
        {
            _subCategoryAppService = subCategoryAppService;
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            var Subcategories = await _subCategoryAppService.GetAll(default);
            return View(Subcategories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var subcategory = await _subCategoryAppService.GetById(id,default);
            if (subcategory == null) { return NotFound(); }
            return View(subcategory);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryAppService.GetAll(default);
            return View ();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubCategoryDto model)
        {
            if (ModelState.IsValid)
                return View(model);
            await _subCategoryAppService.Create(model, default);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var subcategory = await _subCategoryAppService.GetById(id, default);
            if (subcategory == null) { return NotFound(); }
            ViewBag.Categories = await _categoryAppService.GetAll(default);
            return View(subcategory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSubCategoryDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _subCategoryAppService.Update(model, default);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _subCategoryAppService.Delete(id, default);
            return RedirectToAction("Index");
        }
    }
}
