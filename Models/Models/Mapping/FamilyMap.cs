using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Mapping
{
    public class FamilyMap : EntityTypeConfiguration<Family>
    {
        public FamilyMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            //this.Property(t => t.UserId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Family");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.MaritalStatus).HasColumnName("MaritalStatus");
            this.Property(t => t.Anniversary).HasColumnName("Anniversary");

            // Relationships
            this.HasRequired(t => t.User)
                .WithOptional(t => t.Family);

        }

    }
}