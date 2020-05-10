using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class ResolutionMap : EntityTypeConfiguration<Resolution>
    {
        public ResolutionMap()
        {
            // Primary Key
            this.HasKey(t => t.ResolutionID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Resolution");
            this.Property(t => t.ResolutionID).HasColumnName("ResolutionID");
            this.Property(t => t.SurveyID).HasColumnName("SurveyID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.message).HasColumnName("message");
            this.Property(t => t.Resolved).HasColumnName("Resolved");
            this.Property(t => t.Time).HasColumnName("Time");

            // Relationships
            this.HasOptional(t => t.Survey)
                .WithMany(t => t.Resolutions)
                .HasForeignKey(d => d.SurveyID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.Resolutions)
                .HasForeignKey(d => d.UserId);

        }
    }
}
