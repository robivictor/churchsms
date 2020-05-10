using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class GroupedMessage
    {
        public GroupedMessage()
        {
            this.Messages = new List<Message>();           
        }
        public Guid Id { get; set; }
        public string GroupedMessageName { get; set; }
        public string Message { get; set; }
        public int Type { get; set; }
        public DateTime TrrigeredTime { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}