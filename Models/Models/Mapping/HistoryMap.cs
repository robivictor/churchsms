using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Mapping
{
    public class HistoryMap : EntityTypeConfiguration<History>
    {
        public HistoryMap()
        {
            this.HasKey(t => t.UserId);

            this.ToTable("History");

            this.Property(t => t.SalvationDate).HasColumnName("SalvationDate");
            this.Property(t => t.OriginalChurch).HasColumnName("OriginalChurch");
            this.Property(t => t.BabtisimDate).HasColumnName("BabtisimDate");
            this.Property(t => t.JoiningReason).HasColumnName("JoiningReason");
            this.Property(t => t.WithOfficialLetter).HasColumnName("WithOfficialLetter");
            this.Property(t => t.LetterReason).HasColumnName("LetterReason");
            this.Property(t => t.JoinedDate).HasColumnName("JoinedDate");

            this.HasRequired(t => t.User)
                .WithOptional(t => t.History);
        }
    }
}
