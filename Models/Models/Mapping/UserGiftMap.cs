using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class UserGiftMap : EntityTypeConfiguration<UserGift>
    {

        public UserGiftMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserGift");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GiftID).HasColumnName("GiftID");
            this.Property(t => t.UserID).HasColumnName("UserID");

            // Relationships
            this.HasRequired(t => t.Gift)
                .WithMany(t => t.UserGifts)
                .HasForeignKey(d => d.GiftID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserGifts)
                .HasForeignKey(d => d.UserID);

        }
    }
}
