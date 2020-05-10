using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class SurveyStatu
    {
        public SurveyStatu()
        {
            this.Surveys = new List<Survey>();
        }

        public int SurveyStatusID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
