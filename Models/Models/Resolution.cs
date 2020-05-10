using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class Resolution
    {
        public int ResolutionID { get; set; }
        public Nullable<int> SurveyID { get; set; }
        public Nullable<int> UserId { get; set; }
        public string message { get; set; }
        public Nullable<bool> Resolved { get; set; }
        public System.DateTime Time { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual User User { get; set; }
    }
}
