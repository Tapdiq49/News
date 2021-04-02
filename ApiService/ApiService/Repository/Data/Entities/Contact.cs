namespace Repository.Data.Entities
{
    public class Contact : BaseEntity
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
