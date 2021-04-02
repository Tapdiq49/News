using System.Collections.Generic;

namespace Repository.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
