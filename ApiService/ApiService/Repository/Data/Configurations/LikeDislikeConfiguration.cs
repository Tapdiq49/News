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
            builder.HasOne(e => e.News).WithMany().HasForeignKey(e => e.NewsId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("LikesDislikes");
        }
    }
}
