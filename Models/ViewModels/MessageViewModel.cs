using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.ViewModels
{
    public class MessageViewModel
    {
        public string From { get; set; }
        public string Request { get; set; }
        public DateTime Time { get; set; }

    }

    public class UserAccountViewModel
    {
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCurrent { get; set; }
    }

    public class ContactViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Selected { get; set; }
       // public bool IsLeader { get; set; }
    }

    public class GroupedMessageViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public int Percentage { get; set; }
        public int Count { get; set; }
        public int Type { get; set; }
    }


    public class TagViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        // public bool IsLeader { get; set; }
    }

    public class GroupViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public bool Selected { get; set; }
        // public bool IsLeader { get; set; }
    }

    public class LookupViewModel
    { 
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }
        public int Total { get; set; }
    }

    public class GiftViewModel
    {
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        //public int Count { get; set; }
        public bool Selected { get; set; }
        // public bool IsLeader { get; set; }
    }

    public class MessageHistoryViewModel
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public int? StatusID { get; set; }
        public string Status { get; set; }
        public bool Direction { get; set; }
        public int Source { get; set; }
        public int Id { get; set; }
    }

    public class SurveyViewModel
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public decimal Progress { get; set; }
        public int Questions { get; set; }
        public int Participants { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
    }
    public class MessageTobeSent
    {
        public int to { get; set; }
        public string body { get; set; }

    }

}
