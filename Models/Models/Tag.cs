using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Tag
    {
        public Tag()
        {
            this.GroupTags = new List<GroupTag>();
        }
        public int TagId { get; set; }
        public string TagName { get; set; }
        public ICollection<GroupTag> GroupTags { get; set; }
    }
}
