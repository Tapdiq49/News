using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Data.Entities;

namespace Repository.Data.Configurations
{
    class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(e => e.Title).HasMaxLength(150).IsRequired();
            builder.Property(e => e.Text).HasColumnType("ntext").IsRequired();
            builder.Property(e => e.VideoLink).HasMaxLength(150);
            builder.Property(e => e.Comment).IsRequired();
            builder.Property(e => e.Like).IsRequired().HasDefaultValue(0);
            builder.Property(e => e.Dislike).IsRequired().HasDefaultValue(0);
            builder.Property(e => e.View).IsRequired().HasDefaultValue(0);
            builder.HasOne(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Photos).WithOne().HasForeignKey(e => e.NewsId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("News");
        }
    }
}
