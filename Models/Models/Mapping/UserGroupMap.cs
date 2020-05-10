using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class UserGroupMap : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.UserGroupID);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserGroups");
            this.Property(t => t.UserGroupID).HasColumnName("UserGroupID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.GroupID).HasColumnName("GroupID");
            this.Property(t => t.RoleID).HasColumnName("RoleID");

            // Relationships
            this.HasOptional(t => t.GroupRole)
                .WithMany(t => t.UserGroups)
                .HasForeignKey(d => d.RoleID);
            this.HasRequired(t => t.Group)
                .WithMany(t => t.UserGroups)
                .HasForeignKey(d => d.GroupID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserGroups)
                .HasForeignKey(d => d.UserID);

        }
    }
}
