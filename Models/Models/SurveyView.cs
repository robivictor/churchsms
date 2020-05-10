using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class SurveyView
    {
        public string Response { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Question { get; set; }
        public string SurveyName { get; set; }
        public int SurveyId { get; set; }
    }
}
