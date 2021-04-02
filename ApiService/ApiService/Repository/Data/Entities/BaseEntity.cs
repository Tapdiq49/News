using System;

namespace Repository.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool SoftDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
