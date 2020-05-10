using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class SurveyStatuMap : EntityTypeConfiguration<SurveyStatu>
    {
        public SurveyStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.SurveyStatusID);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SurveyStatus");
            this.Property(t => t.SurveyStatusID).HasColumnName("SurveyStatusID");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
