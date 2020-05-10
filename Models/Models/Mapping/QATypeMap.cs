using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class QATypeMap : EntityTypeConfiguration<QAType>
    {
        public QATypeMap()
        {
            // Primary Key
            this.HasKey(t => t.TypeId);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("QAType");
            this.Property(t => t.TypeId).HasColumnName("TypeId");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
