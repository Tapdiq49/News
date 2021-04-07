using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Data.Entities;

namespace Repository.Data.Configurations
{
    class NewsPhotoConfiguration : IEntityTypeConfiguration<NewsPhoto>
    {
        public void Configure(EntityTypeBuilder<NewsPhoto> builder)
        {
            builder.HasIndex(e => new { e.OrderBy, e.NewsId }).IsUnique();
            builder.Property(e => e.Main).IsRequired();
            builder.Property(e => e.Image).HasMaxLength(150).IsRequired();

            builder.ToTable("NewsPhotos");
        }
    }
}
