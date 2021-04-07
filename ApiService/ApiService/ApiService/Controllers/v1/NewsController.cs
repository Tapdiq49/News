using ApiService.Resources.News;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Entities;
using Repository.Exceptions;
using Repository.Models;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers.v1
{
    [ApiVersion("1.0")]
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllNews([FromQuery] int viewCount)
        {
            var news = await _newsService.GetAllNews(viewCount);
            var newsResource = _mapper.Map<NewsResponse, NewsResponseResource>(news);
            return Ok(newsResource);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetNews([FromRoute] int id)
        {
            try
            {
                var news = await _newsService.GetNews(id);
                return Ok(news);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, new { e.Message });
            }
        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetSearchByTitleLike([FromBody] SearchResource search)
        {
            var news = await _newsService.GetSearchByTitleLike(search.search);
            return Ok(news);
        }

        [HttpGet]
        [Route("lastnews")]
        public async Task<IActionResult> GetLastNews()
        {
            var news = await _newsService.GetLastNews();
            return Ok(news);
        }

        [HttpGet]
        [Route("slider")]
        public async Task<IActionResult> GetSliderByNews()
        {
            var news = await _newsService.GetSliderByNews();
            return Ok(news);
        }

        [HttpGet]
        [Route("sortedtime")]
        public async Task<IActionResult> GetNewsSortedByTime()
        {
            var news = await _newsService.GetNewsSortedByView();
            return Ok(news);
        }

        [HttpGet]
        [Route("sortedlike")]
        public async Task<IActionResult> GetNewsSortedByLike()
        {
            var news = await _newsService.GetNewsSortedByLike();
            return Ok(news);
        }

        //[HttpPost]
        //[Route("like")]
        //public IActionResult Like([FromBody] string token, [FromRoute] int newsId)
        //{
        //    Response.Cookies.Append(token, Guid.NewGuid().ToString(), new Microsoft.AspNetCore.Http.CookieOptions
        //    {
        //        Expires = DateTime.Now.AddYears(2),
        //        HttpOnly = true
        //    });

        //    _newsService.LikeDislike(token, newsId);
        //    return NoContent();
        //}

        //[HttpPost]
        //[Route("dislike")]
        //public IActionResult Dislike([FromBody] string token, [FromRoute] int newsId)
        //{
        //    Response.Cookies.Append(token, Guid.NewGuid().ToString(), new Microsoft.AspNetCore.Http.CookieOptions
        //    {
        //        Expires = DateTime.Now.AddYears(2),
        //        HttpOnly = true
        //    });

        //    _newsService.LikeDislike(token, newsId);
        //    return NoContent();
        //}
    }
}
