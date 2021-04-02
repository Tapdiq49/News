using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Resources.News
{
    public class NewsResponseResource
    {
        public IEnumerable<NewsResource> news { get; set; }
        public int count { get; set; }
    }
}
