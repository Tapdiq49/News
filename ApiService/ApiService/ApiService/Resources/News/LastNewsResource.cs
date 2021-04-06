using Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Resources.News
{
    public class LastNewsResource
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public ICollection<NewsPhoto> Photos { get; set; }
    }
}
