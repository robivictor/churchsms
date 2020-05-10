using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int? UserRefId { get; set; }
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }
        public virtual FamilyMemberType FamilyMemberType { get; set; }
        public virtual User User { get; set; }
    }
}