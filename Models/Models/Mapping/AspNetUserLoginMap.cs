using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class AspNetUserLoginMap : EntityTypeConfiguration<AspNetUserLogin>
    {
        public AspNetUserLoginMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey });

            // Properties
            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.LoginProvider)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.ProviderKey)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("AspNetUserLogins");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.LoginProvider).HasColumnName("LoginProvider");
            this.Property(t => t.ProviderKey).HasColumnName("ProviderKey");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.AspNetUserLogins)
                .HasForeignKey(d => d.UserId);

        }
    }
}
