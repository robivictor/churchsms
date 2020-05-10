namespace DataModels.Models
{
    public partial class UserGift
    {
        public int Id { get; set; }
        public int GiftID { get; set; }
        public int UserID { get; set; }
        public virtual Gift Gift { get; set; }
        public virtual User User { get; set; }
    }
}
