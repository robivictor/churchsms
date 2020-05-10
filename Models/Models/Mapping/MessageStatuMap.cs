using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class MessageStatuMap : EntityTypeConfiguration<MessageStatu>
    {
        public MessageStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.StatusID);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MessageStatus");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
