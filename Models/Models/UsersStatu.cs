using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public class UsersStatu
    {
        public UsersStatu()
        {
            this.Users = new List<User>();
        }

        public int UsersStatusId { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
