using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class SurveyViewMap : EntityTypeConfiguration<SurveyView>
    {
        public SurveyViewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Response, t.Name, t.PhoneNumber, t.SurveyName, t.SurveyId });

            // Properties
            this.Property(t => t.Response)
                .IsRequired()
                .HasMaxLength(160);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Question)
                .HasMaxLength(160);

            this.Property(t => t.SurveyName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SurveyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SurveyView");
            this.Property(t => t.Response).HasColumnName("Response");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Question).HasColumnName("Question");
            this.Property(t => t.SurveyName).HasColumnName("SurveyName");
            this.Property(t => t.SurveyId).HasColumnName("SurveyId");
        }
    }
}
