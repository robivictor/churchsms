using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Family
    {
        public Family()
        {
            this.FamilyMembers = new List<FamilyMember>();
        }

        public int UserId { get; set; }
        public int MaritalStatus { get; set; }
        public DateTime? Anniversary { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}