using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class GroupRole
    {
        public GroupRole()
        {
            this.UserGroups = new List<UserGroup>();
        }

        public int groupRoleID { get; set; }
        public string Role { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
