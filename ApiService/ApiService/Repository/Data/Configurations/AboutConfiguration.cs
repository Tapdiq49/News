using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Data.Entities;

namespace Repository.Data.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(e => e.Title).HasMaxLength(150).IsRequired();
            builder.Property(e => e.Text).HasColumnType("ntext").IsRequired();

            builder.ToTable("Abouts");
        }
    }
}
