using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class UserGroup
    {
        public int UserGroupID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public int? RoleID { get; set; }
        public virtual GroupRole GroupRole { get; set; }
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
