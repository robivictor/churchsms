using System;

namespace ChurchSMS_offline
{
    public  class  MessageValidate
    {
        public DateTime ToDateTime(double unixTimeStamp)
        {
            //Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public DateTime Stamp2DateTime(double timestamp)
        {
            return  new DateTime();
        }
    }
}
