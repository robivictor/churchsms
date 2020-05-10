using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Mapping
{
    public class FamilyMemberMap : EntityTypeConfiguration<FamilyMember>
    {
        public FamilyMemberMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                 .IsRequired()
                 .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("FamilyMembers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TypeId).HasColumnName("TypeId");
            this.Property(t => t.UserRefId).HasColumnName("UserRefId");
            this.Property(t => t.FamilyId).HasColumnName("FamilyId");

            // Relationships
            this.HasRequired(t => t.Family)
                .WithMany(t => t.FamilyMembers)
                .HasForeignKey(d => d.FamilyId);
            this.HasRequired(t => t.FamilyMemberType)
                .WithMany(t => t.FamilyMembers)
                .HasForeignKey(d => d.TypeId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.FamilyMembers)
                .HasForeignKey(d => d.UserRefId);
        }
    }
}
