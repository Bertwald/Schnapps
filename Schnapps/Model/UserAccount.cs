namespace Schnapps.Model {
    internal class UserAccount
    {
        #region Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public User UserInfo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        // TODO: When Database => count failed logins to lock accounts
        //public int FailedLoginCounter { get; set; }
        #endregion
    }
}
