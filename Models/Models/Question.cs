using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class Question
    {
        public Question()
        {
            this.Answers = new List<Answer>();
        }

        public int QuestionId { get; set; }
        public int QuestionType { get; set; }
        public int Survey_SurveyId { get; set; }
        public string Question1 { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual QAType QAType { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
