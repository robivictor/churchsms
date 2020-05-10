using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class QuestionPoolMap : EntityTypeConfiguration<QuestionPool>
    {
        public QuestionPoolMap()
        {
            // Primary Key
            this.HasKey(t => t.QuestionPoolID);

            // Properties
            this.Property(t => t.Question)
                .HasMaxLength(160);

            // Table & Column Mappings
            this.ToTable("QuestionPool");
            this.Property(t => t.QuestionPoolID).HasColumnName("QuestionPoolID");
            this.Property(t => t.Question).HasColumnName("Question");
            this.Property(t => t.Type).HasColumnName("Type");

            // Relationships
            this.HasRequired(t => t.QAType)
                .WithMany(t => t.QuestionPools)
                .HasForeignKey(d => d.Type);

        }
    }
}
