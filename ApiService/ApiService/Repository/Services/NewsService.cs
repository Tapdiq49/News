using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
using Repository.Exceptions;
using Repository.Models;
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
        public async Task<NewsResponse> GetAllNews(int viewCount)
        {
            var count = viewCount + 20;
            var news = await _context.News.OrderByDescending(n=>n.CreatedAt).Where(n => !n.SoftDeleted).Include(n=>n.Photos).Include(n=>n.Category).Skip(viewCount).Take(count).ToListAsync();
            var res = new NewsResponse(news, viewCount + news.Count);
            return res;
        }

        public async Task<IEnumerable<News>> GetCategoryAllNews(int categoryId)
        {
            var news = await _context.News.Where(e => e.CategoryId == categoryId || e.Category.ParentId == categoryId).Include(e => e.Category).ToListAsync();
            if(news == null) throw new NotFoundException("Bu Kategoriyada xeber tapilmadi");
            return news;
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

        public async Task<IEnumerable<News>> GetSearchByTitleLike(string search)
        {
            return await _context.News.Where(e => !e.SoftDeleted && e.Title.Contains(search)).Take(30).ToListAsync();
        }
    }
}
