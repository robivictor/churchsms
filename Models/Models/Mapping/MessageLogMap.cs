using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class MessageLogMap : EntityTypeConfiguration<MessageLog>
    {
        public MessageLogMap()
        {
            // Primary Key
            this.HasKey(t => t.MessageID);

            // Properties
            this.Property(t => t.MessageBody)
                .HasMaxLength(200);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MessageLog");
            this.Property(t => t.MessageID).HasColumnName("MessageID");
            this.Property(t => t.MessageBody).HasColumnName("MessageBody");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Time).HasColumnName("Time");
        }
    }
}
