using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Data.Entities;

namespace Repository.Data.Configurations
{
    class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(e => e.Phone).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(50).IsRequired();

            builder.ToTable("Contacts");
        }
    }
}
