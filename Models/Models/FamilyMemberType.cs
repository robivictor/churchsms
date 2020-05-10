using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public partial class FamilyMemberType
    {
        public FamilyMemberType()
        {
            this.FamilyMembers = new List<FamilyMember>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}