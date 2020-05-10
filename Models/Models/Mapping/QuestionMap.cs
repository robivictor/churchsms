using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.QuestionId);

            // Properties
            this.Property(t => t.Question1)
                .HasMaxLength(160);

            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.QuestionType).HasColumnName("QuestionType");
            this.Property(t => t.Survey_SurveyId).HasColumnName("Survey_SurveyId");
            this.Property(t => t.Question1).HasColumnName("Question");

            // Relationships
            this.HasRequired(t => t.QAType)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.QuestionType);
            this.HasRequired(t => t.Survey)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.Survey_SurveyId);

        }
    }
}
