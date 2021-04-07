using System.Collections.Generic;

namespace ApiService.Resources.News
{
    public class NewsResponseResource
    {
        public IEnumerable<NewsResource> news { get; set; }
        public int count { get; set; }
    }
}
