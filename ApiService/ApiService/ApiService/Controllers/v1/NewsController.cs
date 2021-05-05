using ApiService.Resources.News;
using Microsoft.AspNetCore.Cors;
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
        public async Task<IActionResult> GetSearchByTitleLike([FromQuery] string search, [FromQuery] int viewCount)
        {
            var news = await _newsService.GetSearchByTitleLike(search, viewCount);
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

        [HttpGet]
        [Route("lastnews")]
        public async Task<IActionResult> GetLastNews([FromQuery] int count)
        {
            var news = await _newsService.GetLastNews(count);
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

        [HttpPost]
        [Route("{newsId:int}/like")]                
        public async Task<IActionResult> Like([FromRoute] int newsId)
        {
            string token;
            string tokenOptional;
            if (Request.Cookies.TryGetValue("token", out tokenOptional))
            {
                token = tokenOptional;
            }
            else
            {
                token = Guid.NewGuid().ToString();
            }

            Response.Cookies.Append("token", token, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddYears(2),
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });
            try
            {
                var news = await _newsService.LikeDislike(token, newsId, true);
                return Ok(news);
            }
            catch (InvalidInputException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, new { e.Message });
            }
        }

        [HttpPost]
        [Route("{newsId:int}/dislike")]
        public async Task<IActionResult> Dislike([FromRoute] int newsId)
        {
            string token;
            string tokenOptional;
            if (Request.Cookies.TryGetValue("token", out tokenOptional))
            {
                token = tokenOptional;
            }
            else
            {
                token = Guid.NewGuid().ToString();
            }

            Response.Cookies.Append("token", token, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddYears(2),
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });
            try
            {
                var news = await _newsService.LikeDislike(token, newsId, false);
                return Ok(news);
            }
            catch (InvalidInputException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, new { e.Message });
            }
        }
    }
}
