using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Data.Entities;

namespace Repository.Data.Configurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.ParentId).IsRequired(false);
            builder.HasMany(e => e.SubCategories).WithOne().HasForeignKey(e => e.ParentId).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Categories");
        }
    }
}
