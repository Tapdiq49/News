using Admin.Filters;
using Admin.Models.News;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Entities;
using Repository.Exceptions;
using Repository.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class CategoryController : Controller
    {
        private Repository.Data.Entities.Admin _admin => RouteData.Values["Admin"] as Repository.Data.Entities.Admin;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            var model = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category category = _mapper.Map<CategoryViewModel, Category>(model);
                    category.ModifiedBy = _admin.Fullname;

                    await _categoryService.CreateCategory(category);
                }catch(NotFoundException e)
                {
                    ModelState.AddModelError("Email", "Bu e-poçt ünvanı artıq movcuddur");
                }
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("index");
            }

            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _categoryService.GetCategoryById(id);

            if (category == null) return NotFound();

            var model = _mapper.Map<Category, CategoryViewModel>(category);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = _mapper.Map<CategoryViewModel, Category>(model);
                category.ModifiedBy = _admin.Fullname;

                Category categoryToUpdate = await _categoryService.GetCategoryById(model.Id);

                if (categoryToUpdate == null) return NotFound();

                await _categoryService.UpdateCategory(categoryToUpdate, category);

                return RedirectToAction("index");
            }

            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _categoryService.GetCategoryById(id);

            if (category == null) return NotFound();

            await _categoryService.DeleteCategory(category);

            return RedirectToAction("index");
        }
    }
}
