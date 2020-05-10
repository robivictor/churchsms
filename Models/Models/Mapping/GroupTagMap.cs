using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Mapping
{
    public class GroupTagMap : EntityTypeConfiguration<GroupTag>
    {
        public GroupTagMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("GroupTags");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TagId).HasColumnName("TagID");
            this.Property(t => t.GroupId).HasColumnName("GroupID");

            // Relationships
           this.HasRequired(t => t.Group)
                .WithMany(t => t.GroupTags)
                .HasForeignKey(d => d.GroupId);
            this.HasRequired(t => t.Tag)
                .WithMany(t => t.GroupTags)
                .HasForeignKey(d => d.TagId);

        }
    }
}
