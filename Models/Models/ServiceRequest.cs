using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class ServiceRequest
    {
        public int ServiceRequestID { get; set; }
        public Nullable<int> ServiceCodeID { get; set; }
        public string RequestFromNumber { get; set; }
        public System.DateTime RequestTime { get; set; }
        public string RequestFromName { get; set; }
        public virtual ServiceCode ServiceCode { get; set; }
    }
}
