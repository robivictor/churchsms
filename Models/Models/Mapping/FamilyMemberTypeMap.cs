using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class FamilyMemberTypeMap : EntityTypeConfiguration<FamilyMemberType>
    {
        public FamilyMemberTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.TypeId);

            // Properties
            this.Property(t => t.TypeName)
                .IsRequired()
               .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FamilyMemberType");
            this.Property(t => t.TypeId).HasColumnName("TypeId");
            this.Property(t => t.TypeName).HasColumnName("TypeName");
        }
    }
}