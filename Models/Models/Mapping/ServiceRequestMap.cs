using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataModels.Models.Mapping
{
    public class ServiceRequestMap : EntityTypeConfiguration<ServiceRequest>
    {
        public ServiceRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.ServiceRequestID);

            // Properties
            this.Property(t => t.RequestFromNumber)
                .HasMaxLength(50);

            this.Property(t => t.RequestFromName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ServiceRequests");
            this.Property(t => t.ServiceRequestID).HasColumnName("ServiceRequestID");
            this.Property(t => t.ServiceCodeID).HasColumnName("ServiceCodeID");
            this.Property(t => t.RequestFromNumber).HasColumnName("RequestFromNumber");
            this.Property(t => t.RequestTime).HasColumnName("RequestTime");
            this.Property(t => t.RequestFromName).HasColumnName("RequestFromName");

            // Relationships
            this.HasOptional(t => t.ServiceCode)
                .WithMany(t => t.ServiceRequests)
                .HasForeignKey(d => d.ServiceCodeID);

        }
    }
}
