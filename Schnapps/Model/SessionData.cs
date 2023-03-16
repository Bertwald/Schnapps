using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schnapps.Model {
    // Singleton containing the data with which we identify the unique users of our application,
    // gives access to database id for the UserAccount and user specific paths for savefiles
    internal class SessionData {
        public static SessionData _instance;
        // Sometimes the C# syntax is almost too good, returns instance iff there is one, otherwise sets and returns the instance
        public static SessionData GetInstance() { return _instance ??= new(); }
        public void CleanInstance() { User = null; UserSavedData = new(); }
        private SessionData() { UserSavedData = new(); }
        public User User { get; set; }
        public List<Recipe> UserSavedData { get; set; }
    }
}
