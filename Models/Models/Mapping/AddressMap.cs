using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.HasKey(t => t.UserId);

            this.ToTable("MemberAddress");
            this.Property(t => t.Subcity).HasColumnName("SubCity");
            this.Property(t => t.Subrub).HasColumnName("Subrub");
            this.Property(t => t.Kebele).HasColumnName("Kebele");
            this.Property(t => t.HouseNumber).HasColumnName("HouseNumber");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.WorkPhone).HasColumnName("WorkPhone");
            this.Property(t => t.HomePhone).HasColumnName("HomePhone");
            this.Property(t => t.Post).HasColumnName("Post");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Facebook).HasColumnName("Facebook");
            this.Property(t => t.Twitter).HasColumnName("Twitter");

            this.HasRequired(t => t.User)
                .WithOptional(t => t.Address);
        }
    }
}
