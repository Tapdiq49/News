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
        Task<IEnumerable<News>> GetLastNews();
        Task<IEnumerable<News>> GetSliderByNews();
        Task<IEnumerable<News>> GetNewsSortedByView();
        Task<IEnumerable<News>> GetNewsSortedByLike();
        Task<News> LikeDislike(string token, int newsId, bool isLiked);
        Task<IEnumerable<News>> GetNews();
        News CreateNews(News news);
        News GetNewsById(int id);
        void RemovePhotoById(int id);
        void AddPhoto(NewsPhoto newsPhoto);
        void UpdateNews(News newsToUpdate, News news);
        void DeleteNews(News news);
        NewsPhoto GetNewsPhotoById(int id);
        void UpdateNewsPhoto(NewsPhoto newsPhotoToUpdate, NewsPhoto newsPhoto);
    }
}
