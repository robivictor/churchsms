using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Mapping
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        // Primary Key
        public TagMap()
        {
            // Primary Key
            this.HasKey(t => t.TagId);

            // Properties
            this.Property(t => t.TagName)
                .IsRequired()
                .HasMaxLength(50);

            this.ToTable("Tags");
            this.Property(t => t.TagId).HasColumnName("TagId");
            this.Property(t => t.TagName).HasColumnName("TagName");
        }
    }
}
