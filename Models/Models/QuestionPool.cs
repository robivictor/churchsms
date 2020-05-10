using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class QuestionPool
    {
        public int QuestionPoolID { get; set; }
        public string Question { get; set; }
        public int Type { get; set; }
        public virtual QAType QAType { get; set; }
    }
}
