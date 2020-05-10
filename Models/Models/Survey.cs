using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class Survey
    {
        public Survey()
        {
            this.Questions = new List<Question>();
            this.Resolutions = new List<Resolution>();
            this.Users = new List<User>();
            this.Users1 = new List<User>();
        }

        public int SurveyId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<int> Status { get; set; }
        public string SurveyName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Resolution> Resolutions { get; set; }
        public virtual SurveyStatu SurveyStatu { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<User> Users1 { get; set; }
    }
}
