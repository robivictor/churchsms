using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.AnswerId);

            // Properties
            this.Property(t => t.Response)
                .IsRequired()
                .HasMaxLength(160);

            // Table & Column Mappings
            this.ToTable("Answers");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");
            this.Property(t => t.Response).HasColumnName("Response");
            this.Property(t => t.Question_QuestionId).HasColumnName("Question_QuestionId");
            this.Property(t => t.User_UserId).HasColumnName("User_UserId");
            this.Property(t => t.AnswerType).HasColumnName("AnswerType");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");

            // Relationships
            this.HasRequired(t => t.PossibleAnswer)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.AnswerType);
            this.HasRequired(t => t.Question)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.Question_QuestionId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.User_UserId);

        }
    }
}
