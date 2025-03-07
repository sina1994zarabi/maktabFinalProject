using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities.Services;
using App.Domain.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace App.EndPoints.MVC.Components.CategoryMenu
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IMemoryCache _cache;

        public CategoryMenuViewComponent(ICategoryAppService categoryAppService,
                                         IMemoryCache cache)
        {
            _categoryAppService = categoryAppService;
            _cache = cache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string cacheKey = "categories";

            if (!_cache.TryGetValue(cacheKey, out List<Category> categories))
            {
                categories = await _categoryAppService.GetAll(default);
                _cache.Set(cacheKey, categories, TimeSpan.FromMinutes(30));
            }
            return View(categories);
        }
    }
}
