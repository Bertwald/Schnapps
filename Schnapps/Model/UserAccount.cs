using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Channels;

namespace Schnapps.Model
{
    internal class UserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public User UserInfo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        //public int FailedLoginCounter { get; set; }
    }
}
