using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.Entities;
using Repository.Exceptions;
using Repository.Models;
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
            var news = await _context.News.Where(p => !p.SoftDeleted).Include(e=>e.Photos).Include(e=>e.Category).Skip(viewCount).Take(count).ToListAsync();
            var res = new NewsResponse(news, viewCount + news.Count);
            return res;
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
                throw new NewsNotFoundException("Xeber tapılmadı");
            }

            return view;
        }
    }
}
