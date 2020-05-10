using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class MessageLog
    {
        public int MessageID { get; set; }
        public string MessageBody { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
    }
}
