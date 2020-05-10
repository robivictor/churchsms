using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            // Primary Key
            this.HasKey(t => t.MessageID);

            // Properties
            this.Property(t => t.msg_body)
                .IsRequired()
                .HasMaxLength(160);

            this.Property(t => t.SentBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Messages");
            this.Property(t => t.MessageID).HasColumnName("MessageID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.msg_body).HasColumnName("msg_body");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.ScheduledTime).HasColumnName("ScheduledTime");
            this.Property(t => t.SentTime).HasColumnName("SentTime");
            this.Property(t => t.RecievedTime).HasColumnName("RecievedTime");
            this.Property(t => t.SentBy).HasColumnName("SentBy");
            this.Property(t => t.ParentGroupID).HasColumnName("ParentGroup");

            // Relationships
            this.HasRequired(t => t.MessageStatu)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.Status);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.UserId);
            this.HasOptional(t => t.ParentGroup)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.ParentGroupID);

        }
    }
}
