using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class Group
    {
        public Group()
        {
            this.UserGroups = new List<UserGroup>();
            this.GroupTags = new List<GroupTag>();
        }

        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<GroupTag> GroupTags { get; set; }
    }
}
