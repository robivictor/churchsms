using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Gift
    {
        public Gift()
        {
            this.UserGifts = new List<UserGift>();
        }
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public virtual ICollection<UserGift> UserGifts { get; set; }
    }
}
