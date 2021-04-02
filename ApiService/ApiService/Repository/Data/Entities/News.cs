using System.Collections.Generic;

namespace Repository.Data.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Comment { get; set; }
        public int CategoryId { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public int View { get; set; }
        public string VideoLink { get; set; }
        public ICollection<NewsPhoto> Photos { get; set; }
        public Category Category { get; set; }
    }
}
