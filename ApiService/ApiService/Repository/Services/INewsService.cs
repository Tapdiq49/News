using Repository.Data.Entities;
using Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface INewsService
    {
        Task<NewsResponse> GetAllNews(int viewCount);
        Task<News> GetNews(int id);
        Task<IEnumerable<News>> GetCategoryAllNews(int categoryId);
        Task<IEnumerable<News>> GetSearchByTitleLike(string search);
        Task<IEnumerable<News>> GetLastNews();
        Task<IEnumerable<News>> GetSliderByNews();
        Task<IEnumerable<News>> GetNewsSortedByView();
        Task<IEnumerable<News>> GetNewsSortedByLike();

        //Task LikeDislike(string token, int newsId);
    }
}
