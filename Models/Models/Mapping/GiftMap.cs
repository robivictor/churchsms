using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Mapping
{
    public class GiftMap : EntityTypeConfiguration<Gift>
    {
        public GiftMap()
        {
            // Primary Key
            this.HasKey(t => t.GiftId);

            // Properties
            this.Property(t => t.GiftName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Gift");
            this.Property(t => t.GiftId).HasColumnName("GiftID");
            this.Property(t => t.GiftName).HasColumnName("GiftName");
        }
    }
}