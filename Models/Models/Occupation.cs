using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Occupation
    {
        public Occupation()
        {
            this.Users = new List<User>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
