using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace efdemo.Model.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ExpanseUser>
    {
        public void Configure(EntityTypeBuilder<ExpanseUser> builder)
        {
            builder
                .Property(u => u.FullName)
                .HasComputedColumnSql("[FirstName]+ ' ' + [LastName]");

            builder.Property(u => u.CreatedDate).ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(u => u.LastModified).ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
