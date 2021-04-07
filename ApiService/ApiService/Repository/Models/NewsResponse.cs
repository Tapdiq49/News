using Repository.Data.Entities;
using System.Collections.Generic;

namespace Repository.Models
{
    public class NewsResponse
    {
        public IEnumerable<News> news { get; }
        public int count { get; }
        public NewsResponse(IEnumerable<News> resNews, int resCount)
        {
            news = resNews;
            count = resCount;
        }


    }
}
