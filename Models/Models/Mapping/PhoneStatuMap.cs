using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class PhoneStatuMap : EntityTypeConfiguration<PhoneStatu>
    {
        public PhoneStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.PhoneId);

            // Properties
            this.Property(t => t.PhoneId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SIM_Number)
                .HasMaxLength(50);

            this.Property(t => t.Network)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PhoneStatus");
            this.Property(t => t.PhoneId).HasColumnName("PhoneId");
            this.Property(t => t.SIM_Number).HasColumnName("SIM_Number");
            this.Property(t => t.PowerMode).HasColumnName("PowerMode");
            this.Property(t => t.LastConnected).HasColumnName("LastConnected");
            this.Property(t => t.BatteryLevel).HasColumnName("BatteryLevel");
            this.Property(t => t.Network).HasColumnName("Network");
        }
    }
}
