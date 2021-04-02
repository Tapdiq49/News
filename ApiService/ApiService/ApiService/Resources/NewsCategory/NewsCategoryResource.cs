using Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Resources.NewsCategory
{
    public class NewsCategoryResource
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
