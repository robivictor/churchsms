using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class Message
    {
        public int MessageID { get; set; }
        public int UserId { get; set; }
        public string msg_body { get; set; }
        public int Status { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public DateTime? SentTime { get; set; }
        public DateTime? RecievedTime { get; set; }
        public string SentBy { get; set; }
        public Guid? ParentGroupID { get; set; }
        public virtual MessageStatu MessageStatu { get; set; }
        public virtual User User { get; set; }
        public virtual GroupedMessage ParentGroup { get; set; }
    }
}
