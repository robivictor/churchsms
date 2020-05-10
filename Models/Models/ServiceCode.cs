using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class ServiceCode
    {
        public ServiceCode()
        {
            this.ServiceRequests = new List<ServiceRequest>();
        }

        public int ServiceCodeID { get; set; }
        public string Code { get; set; }
        public string Service { get; set; }
        public Nullable<int> Type { get; set; }
        public string Response { get; set; }
        public bool AutoReply { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
