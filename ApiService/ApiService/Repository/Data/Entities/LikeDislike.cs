namespace Repository.Data.Entities
{
    public class LikeDislike : BaseEntity
    {
        public int NewsId { get; set; }
        public string Token { get; set; }
        public News News { get; set; }
    }
}
