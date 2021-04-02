namespace Repository.Data.Entities
{
    public class NewsPhoto : BaseEntity
    {
        public int OrderBy { get; set; }
        public bool Main  { get; set; }
        public string Image { get; set; }
        public int NewsId { get; set; }
    }
}
