using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DataModels.Models.Mapping;

namespace DataModels.Models
{
    public partial class ChurchSMSofflineContext : DbContext
    {
        static ChurchSMSofflineContext()
        {
            Database.SetInitializer<ChurchSMSofflineContext>(null);
        }

        public ChurchSMSofflineContext()
            : base("Name=ChurchSMSofflineContext")
        {
        }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<FamilyMemberType> FamilyMemberTypes { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<GroupedMessage> GroupedMessages { get; set; }
        public DbSet<GroupRole> GroupRoles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupTag> GroupTags { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<MessageLog> MessageLogs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageStatu> MessageStatus { get; set; }
        public DbSet<PhoneStatu> PhoneStatus { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<PossibleAnswer> PossibleAnswers { get; set; }
        public DbSet<QAType> QATypes { get; set; }
        public DbSet<QuestionPool> QuestionPools { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
        public DbSet<ServiceCode> ServiceCodes { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyStatu> SurveyStatus { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<UserGift> UserGifts { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersStatu> UsersStatus { get; set; }
        public DbSet<SurveyView> SurveyViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new FamilyMap());
            modelBuilder.Configurations.Add(new FamilyMemberMap());
            modelBuilder.Configurations.Add(new FamilyMemberTypeMap());
            modelBuilder.Configurations.Add(new GiftMap());
            modelBuilder.Configurations.Add(new GroupMessageMap());
            modelBuilder.Configurations.Add(new GroupRoleMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new GroupTagMap());
            modelBuilder.Configurations.Add(new HistoryMap());
            modelBuilder.Configurations.Add(new MessageLogMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new MessageStatuMap());
            modelBuilder.Configurations.Add(new OccupationMap());
            modelBuilder.Configurations.Add(new PhoneStatuMap());
            modelBuilder.Configurations.Add(new PossibleAnswerMap());
            modelBuilder.Configurations.Add(new QATypeMap());
            modelBuilder.Configurations.Add(new QuestionPoolMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new ResolutionMap());
            modelBuilder.Configurations.Add(new ServiceCodeMap());
            modelBuilder.Configurations.Add(new ServiceRequestMap());
            modelBuilder.Configurations.Add(new SurveyMap());
            modelBuilder.Configurations.Add(new SurveyStatuMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new UserGiftMap());
            modelBuilder.Configurations.Add(new UserGroupMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UsersStatuMap());
            modelBuilder.Configurations.Add(new SurveyViewMap());
        }
    }
}
