using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class GroupRoleMap : EntityTypeConfiguration<GroupRole>
    {
        public GroupRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.groupRoleID);

            // Properties
            this.Property(t => t.Role)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GroupRole");
            this.Property(t => t.groupRoleID).HasColumnName("groupRoleID");
            this.Property(t => t.Role).HasColumnName("Role");
        }
    }
}
