using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class PossibleAnswerMap : EntityTypeConfiguration<PossibleAnswer>
    {
        public PossibleAnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.PossibleAnswerID);

            // Properties
            this.Property(t => t.PossibleAnswerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Value)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PossibleAnswers");
            this.Property(t => t.PossibleAnswerID).HasColumnName("PossibleAnswerID");
            this.Property(t => t.Value).HasColumnName("Value");
        }
    }
}
