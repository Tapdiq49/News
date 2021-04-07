using Repository.Data.Entities;
using System.Collections.Generic;

namespace ApiService.Resources.NewsCategory
{
    public class NewsCategoryResource
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
