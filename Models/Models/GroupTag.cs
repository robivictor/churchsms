using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class GroupTag
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
