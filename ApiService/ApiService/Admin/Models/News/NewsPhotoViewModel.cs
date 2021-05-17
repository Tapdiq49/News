namespace Admin.Models.News
{
    public class NewsPhotoViewModel
    {
        public int Id { get; set; }
        public int OrderBy { get; set; }
        public bool Main { get; set; }
        public string Image { get; set; }
        public int NewsId { get; set; }
    }
}
