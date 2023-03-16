using Schnapps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schnapps.Services
{
    class UserManager
    {

        public static User GetUser(string username, string password) {
#if DEBUG
            if(username=="bertwald" && password == "bertwald") {
                return new User() { Name = "Debug", Alias = "TestUser", Email = "blackhole@devnull.com" };
            }
#endif
            return null;
        }

    }
}
