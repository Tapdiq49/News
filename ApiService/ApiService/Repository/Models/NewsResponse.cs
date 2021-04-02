using Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
