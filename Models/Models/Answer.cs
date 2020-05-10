using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string Response { get; set; }
        public int Question_QuestionId { get; set; }
        public int User_UserId { get; set; }
        public int AnswerType { get; set; }
        public DateTime? TimeStamp { get; set; }
        public virtual PossibleAnswer PossibleAnswer { get; set; }
        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}
