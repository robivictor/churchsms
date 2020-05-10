using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Models
{
    public class User
    {
        public User()
        {
            this.Answers = new List<Answer>();
            this.FamilyMembers = new List<FamilyMember>();
            this.Messages = new List<Message>();
            this.Resolutions = new List<Resolution>();
            this.UserGifts = new List<UserGift>();
            this.UserGroups = new List<UserGroup>();
            this.Surveys = new List<Survey>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public string ReferenceID { get; set; }

        public DateTime? BirthDate { get; set; }
        //public DateTime? JoinedDate { get; set; }
        //public string Email { get; set; }
        //public string Facebook { get; set; }
        public Boolean IsMale { get; set; }
        public int? OccupationID { get; set; }
        public int? CurrentSurvey { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Resolution> Resolutions { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual UsersStatu UsersStatu { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual Address Address { get; set; }
        public virtual Family Family { get; set; }
        public virtual History History { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<UserGift> UserGifts { get; set; }
        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}