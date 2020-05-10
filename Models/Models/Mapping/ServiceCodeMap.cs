using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class ServiceCodeMap : EntityTypeConfiguration<ServiceCode>
    {
        public ServiceCodeMap()
        {
            // Primary Key
            this.HasKey(t => t.ServiceCodeID);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(10);

            this.Property(t => t.Service)
                .HasMaxLength(50);

            this.Property(t => t.Response)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ServiceCodes");
            this.Property(t => t.ServiceCodeID).HasColumnName("ServiceCodeID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Service).HasColumnName("Service");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Response).HasColumnName("Response");
            this.Property(t => t.AutoReply).HasColumnName("AutoReply");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
