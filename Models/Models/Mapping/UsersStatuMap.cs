using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class UsersStatuMap : EntityTypeConfiguration<UsersStatu>
    {
        public UsersStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.UsersStatusId);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UsersStatus");
            this.Property(t => t.UsersStatusId).HasColumnName("UsersStatusId");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
