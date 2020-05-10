using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class SurveyMap : EntityTypeConfiguration<Survey>
    {
        public SurveyMap()
        {
            // Primary Key
            this.HasKey(t => t.SurveyId);

            // Properties
            this.Property(t => t.SurveyName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Surveys");
            this.Property(t => t.SurveyId).HasColumnName("SurveyId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.SurveyName).HasColumnName("SurveyName");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasMany(t => t.Users1)
                .WithMany(t => t.Surveys)
                .Map(m =>
                    {
                        m.ToTable("SurveyUsers");
                        m.MapLeftKey("Survey_SurveyId");
                        m.MapRightKey("Users_UserId");
                    });

            this.HasOptional(t => t.SurveyStatu)
                .WithMany(t => t.Surveys)
                .HasForeignKey(d => d.Status);

        }
    }
}
