using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class PossibleAnswer
    {
        public PossibleAnswer()
        {
            this.Answers = new List<Answer>();
        }

        public int PossibleAnswerID { get; set; }
        public string Value { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
