using Admin.Filters;
using Admin.Libs;
using Admin.Models.News;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Entities;
using Repository.Services;
using Repository.Services.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class NewsController : Controller
    {
        private Repository.Data.Entities.Admin _admin => RouteData.Values["Admin"] as Repository.Data.Entities.Admin;
        private readonly IMapper _mapper;
        private readonly INewsService _newsService;
        private readonly ICategoryService _categoryService; 
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;

        public NewsController(IMapper mapper, 
                              INewsService newsService,
                              ICategoryService categoryService,
                              ICloudinaryService cloudinaryService,
                              IFileManager fileManager
                              )
        {
            _mapper = mapper;
            _newsService = newsService;
            _categoryService = categoryService;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
        }
        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetNews();
            var model = _mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(news);
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var news = _mapper.Map<NewsViewModel, News>(model);
                news.ModifiedBy = _admin.Fullname;

                _newsService.CreateNews(news);

                return RedirectToAction("index");
            }

            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var news =  _newsService.GetNewsById(id);

            if (news == null) return NotFound();

            var model = _mapper.Map<News, NewsViewModel>(news);

            model.CategoryId = news.CategoryId;

            ViewBag.Categories = await _categoryService.GetAllCategories();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var news = _mapper.Map<NewsViewModel, News>(model);

                var newsToUpdate = _newsService.GetNewsById(model.Id);

                if (newsToUpdate == null) return NotFound();

                news.ModifiedBy = _admin.Fullname;

                _newsService.UpdateNews(newsToUpdate, news);

                return RedirectToAction("index");
            }
            ViewBag.Categories =  await _categoryService.GetAllCategories();

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            News news = _newsService.GetNewsById(id);

            if (news == null) return NotFound();

            _newsService.DeleteNews(news);

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file, int? newsId, int? orderBy)
        {

            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);
            if (newsId != null)
            {
                NewsPhoto newsPhoto = new NewsPhoto
                {
                    ModifiedBy = _admin.Fullname,
                    CreatedAt = DateTime.Now,
                    Image = publicId,
                    NewsId = (int)newsId,
                    OrderBy = (int)orderBy
                };
                _newsService.AddPhoto(newsPhoto);
            }
            return Ok(new
            {
                filename = publicId,
                src = _cloudinaryService.BuildUrl(publicId)
            });
        }

        [HttpPost]
        public IActionResult Remove(string name, int? id)
        {
            if (id != null)
            {
                _newsService.RemovePhotoById((int)id);
            }

            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }


    }
}
