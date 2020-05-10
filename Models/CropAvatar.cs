using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class CropAvatar
    {
        private string Src { get; set; }
        private string Data { get; set; }
        private string File { get; set; }
        private string Dst { get; set; }
        private string Type { get; set; }
        private string Extension { get; set; }
        private string SrcDir { get; set; }
        private string DstDir { get; set; }
        private string Msg { get; set; }

        public CropAvatar(string src, string data, string file)
        {
            this.SetSrc(src);
            this.SetData();
            this.SetFile();
            this.Crop(src, this.Dst, data);
        }
        private void SetSrc(string src)
        {
            if (src !=null)
            {
                //var image = new ;
                //var i = System.Web.image
            }
        }
        private void SetData()
        {

        }
        private void SetFile()
        {

        }
        private void Crop(string src, string dst, string data)
        {
        }
        private void SetDst()
        {
        }
        private void CodeToMessage(int code)
        {
        }
        public void GetResult()
        {
        }

        public string GetMsg()
        {
            return Msg;
        }
    }
}
