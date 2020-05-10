using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class MessageStatu
    {
        public MessageStatu()
        {
            this.Messages = new List<Message>();
        }

        public int StatusID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
