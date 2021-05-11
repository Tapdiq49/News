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
        Task<NewsResponse> GetCategoryAllNews(int categoryId, int viewCount);
        Task<NewsResponse> GetSearchByTitleLike(string search, int viewCount);
        Task<IEnumerable<News>> GetLastNews(int count);
        Task<IEnumerable<News>> GetSliderByNews();
        Task<IEnumerable<News>> GetNewsSortedByView();
        Task<IEnumerable<News>> GetNewsSortedByLike();
        Task<News> LikeDislike(string token, int newsId, bool isLiked);
        Task<IEnumerable<News>> GetNews();
        Task<News> CreateNews(News news);
        Task<News> GetNewsById(int id);
        Task RemovePhotoById(int id);
        Task AddPhoto(NewsPhoto newsPhoto);
        Task UpdateNews(News newsToUpdate, News news);
        Task DeleteNews(News news);
        Task<NewsPhoto> GetNewsPhotoById(int id);
        Task UpdateNewsPhoto(NewsPhoto newsPhotoToUpdate, NewsPhoto newsPhoto);
    }
}
