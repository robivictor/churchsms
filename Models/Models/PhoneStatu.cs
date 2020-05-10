using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class PhoneStatu
    {
        public int PhoneId { get; set; }
        public string SIM_Number { get; set; }
        public Nullable<int> PowerMode { get; set; }
        public Nullable<System.DateTime> LastConnected { get; set; }
        public Nullable<int> BatteryLevel { get; set; }
        public string Network { get; set; }
    }
}
