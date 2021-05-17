using ApiService.Resources.News;
using ApiService.Resources.NewsCategory;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Entities;
using Repository.Exceptions;
using Repository.Models;
using Repository.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly INewsService _newsService;
        public CategoryController(ICategoryService categoryService, INewsService newsService)
        {
            _categoryService = categoryService;
            _newsService = newsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCategories()
        {
            var category = await _categoryService.GetAllCategories();
            var categoryResource = _mapper.Map<IEnumerable<Category>, IEnumerable<NewsCategoryResource>>(category);
            return Ok(categoryResource);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            try
            {
                var category = await _categoryService.GetCategory(id);
                return Ok(category);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, new { e.Message });
            }
        }
        [HttpGet]
        [Route("{categoryId:int}/news")]
        public async Task<IActionResult> GetCategoryAllNews([FromRoute] int categoryId, [FromQuery] int viewCount)
        {
            try
            {
                var news = await _newsService.GetCategoryAllNews(categoryId, viewCount);
                var newsResource = _mapper.Map<NewsResponse, NewsResponseResource>(news);
                string tokenOptional;
                Request.Cookies.TryGetValue("token", out tokenOptional);
                if (tokenOptional != null)
                {
                    foreach (var item in newsResource.news)
                    {
                        var likeDislike = item.LikeDislikes.FirstOrDefault(e => e.Token == tokenOptional);
                        if (likeDislike != null)
                        {
                            if (likeDislike.IsLiked)
                            {
                                item.Liked = true;
                            }
                            else
                            {
                                item.Disliked = true;
                            }
                        }
                    }

                }
                return Ok(newsResource);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, new { e.Message });
            }
        }
    }
}