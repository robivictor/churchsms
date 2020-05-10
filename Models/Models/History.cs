using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class History
    {
        public History()
        {

        }
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime? SalvationDate { get; set; }
        public string OriginalChurch { get; set; }
        public DateTime? BabtisimDate { get; set; }
        public string JoiningReason { get; set; }
        public Boolean WithOfficialLetter { get; set; }
        public string LetterReason { get; set; }
        public DateTime JoinedDate { get; set; }
        public virtual User User { get; set; }
    }
}