using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
using Repository.Exceptions;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class NewsService : INewsService
    {
        private readonly AppDbContext _context;
        public NewsService(AppDbContext context)
        {
            _context = context;
        }

        public News CreateNews(News news)
        {
            news.CreatedAt = DateTime.Now;

             _context.News.Add(news);

             _context.SaveChanges();

            return news;
        }

        public async Task<NewsResponse> GetAllNews(int viewCount)
        {
            var count = viewCount + 20;
            var news = await _context.News.OrderByDescending(n=>n.CreatedAt).Where(n => !n.SoftDeleted).Include(n=>n.Photos).Include(n=>n.Category).Skip(viewCount).Take(count).ToListAsync();
            var res = new NewsResponse(news, viewCount + news.Count);
            return res;
        }

        public async Task<NewsResponse> GetCategoryAllNews(int categoryId, int viewCount)
        {
            var count = viewCount + 20;
            var news = await _context.News.OrderByDescending(n => n.CreatedAt).Where(n => !n.SoftDeleted && n.CategoryId==categoryId).Include(n => n.Photos).Include(n => n.Category).Skip(viewCount).Take(count).ToListAsync();
            var res = new NewsResponse(news, viewCount + news.Count);
            return res;
        }

        public async Task<IEnumerable<News>> GetLastNews()
        {
            return await _context.News.OrderByDescending(e => e.CreatedAt).Where(e => !e.SoftDeleted).Take(15).ToListAsync();
        }

        public async Task<News> GetNews(int id)
        {
            var view = await _context.News.FirstOrDefaultAsync(p => !p.SoftDeleted && p.Id==id);
            if (view != null)
            {
                view.View += 1;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("Xeber tapılmadı");
            }

            return view;
        }

        public async Task<IEnumerable<News>> GetNews()
        {
            return await _context.News.Include(n => n.Photos).Include(n => n.Category).OrderByDescending(e=>e.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<News>> GetNewsSortedByLike()
        {
            return await _context.News.OrderByDescending(e => e.Like).Where(e => !e.SoftDeleted).ToListAsync();
        }

        public async Task<IEnumerable<News>> GetNewsSortedByView()
        {
            return await _context.News.OrderByDescending(e => e.View).Where(e => !e.SoftDeleted).ToListAsync();
        }

        public async Task<IEnumerable<News>> GetSearchByTitleLike(string search)
        {
            return await _context.News.Where(e => !e.SoftDeleted && e.Title.Contains(search)).Take(30).ToListAsync();
        }

        public async Task<IEnumerable<News>> GetSliderByNews()
        {
            return await _context.News.OrderByDescending(e => e.View).Where(e => !e.SoftDeleted && e.CreatedAt >= DateTime.Now.AddHours(-24)).Take(5).ToListAsync();
        }

        public async Task<News> LikeDislike(string token, int newsId, bool isLiked)
        {
            var likeDislike = await _context.LikesDislikes.FirstOrDefaultAsync(e => !e.SoftDeleted && e.Token == token && e.NewsId == newsId);
            var news = await _context.News.FirstOrDefaultAsync(e => !e.SoftDeleted && e.Id == newsId);
            if (news == null) throw new NotFoundException("Xeber tapılmadı");

            if (likeDislike == null)
            {
                if (isLiked)
                {
                    news.Like += 1;
                }
                else
                {
                    news.Dislike += 1;
                }
                LikeDislike newLikeDislike = new LikeDislike
                {
                    Token = token,
                    NewsId = newsId
                };
                await _context.LikesDislikes.AddAsync(newLikeDislike);
                await _context.SaveChangesAsync();
            }
            else
            {

                throw new InvalidInputException("Bir xebere iki defe like veya dislike vermez olmaz!");
            }
            return news;
        }
    }
}
