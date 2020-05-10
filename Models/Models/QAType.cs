using System;
using System.Collections.Generic;

namespace DataModels.Models
{
    public partial class QAType
    {
        public QAType()
        {
            this.QuestionPools = new List<QuestionPool>();
            this.Questions = new List<Question>();
        }

        public int TypeId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<QuestionPool> QuestionPools { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
