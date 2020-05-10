using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Address
    {
        public Address()
        {
            
        }
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public string Subcity { get; set; }
        public string Subrub  { get; set; }
        public string Kebele  { get; set; }
        public string HouseNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string Post { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public virtual User User { get; set; }
    }
}
