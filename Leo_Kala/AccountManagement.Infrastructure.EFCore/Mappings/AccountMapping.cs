using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(256);

            builder.Property(x => x.LastName)
                .HasMaxLength(256);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Mobile)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(x => x.Password)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.ProfilePhoto)
                .HasMaxLength(400);

            //builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleId);
        }
    }
}
