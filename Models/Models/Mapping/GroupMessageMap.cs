using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Mapping
{
    public class GroupMessageMap : EntityTypeConfiguration<GroupedMessage>
    {
        public GroupMessageMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.GroupedMessageName)
                .IsRequired()
                .HasMaxLength(50);

            this.ToTable("GroupedMessage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GroupedMessageName).HasColumnName("GroupedMessageName");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.TrrigeredTime).HasColumnName("TrrigeredTime");
        }
    }
}