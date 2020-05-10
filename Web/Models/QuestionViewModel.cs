using System;

namespace ChurchSMS.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public int Responded { get; set; }
    }

    public class ParticipantViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set;}
        public bool Status { get; set; }
    }

    public class AnswerViewModel
    {
        public int AnswerId { get; set; }
        public string Participant { get; set; }
        public string Phone { get; set; }
        public string Response { get; set; }
        public DateTime Time { get; set; }
    }

    public class QuestionPoolViewModel
    {
        public int QuestionPoolID { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
    }

    public class QAViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int AnswerType { get; set; }
        public string Value { get; set; }
    }
}