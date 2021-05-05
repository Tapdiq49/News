using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Data.Entities;

namespace Repository.Data.Configurations
{
    public class LikeDislikeConfiguration : IEntityTypeConfiguration<LikeDislike>
    {
        public void Configure(EntityTypeBuilder<LikeDislike> builder)
        {
            builder.Property(e => e.Token).HasMaxLength(150).IsRequired();
            builder.Property(e => e.IsLiked).IsRequired();

            builder.ToTable("LikesDislikes");
        }
    }
}
