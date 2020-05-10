using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.MiddleName)
                .HasMaxLength(50);

            this.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Member");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CurrentSurvey).HasColumnName("CurrentSurvey");
            this.Property(t => t.ImagePath).HasColumnName("ImagePath");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.OccupationID).HasColumnName("OccupationID");
            this.Property(t => t.IsMale).HasColumnName("IsMale");
            this.Property(t => t.ReferenceID).HasColumnName("ReferenceID");

            // Relationships
            this.HasOptional(t => t.Survey)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.CurrentSurvey);
            this.HasRequired(t => t.UsersStatu)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.Status);
            this.HasOptional(t => t.Address)
                .WithRequired(t => t.User);
            this.HasOptional(t => t.Family)
                .WithRequired(t => t.User);
            this.HasOptional(t => t.Occupation)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.OccupationID);
        }
    }
}
