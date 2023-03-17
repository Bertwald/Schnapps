using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Schnapps.ViewModel {
    public partial class LoginViewModel : BaseViewModel {
        #region Properties
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CanAttemptLogin))]
        private bool passwordOK;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CanAttemptLogin))]
        private bool usernameOK;
        public bool CanAttemptLogin => PasswordOK && UsernameOK;
        #endregion
        #region Constructors
        public LoginViewModel() {

        }
        #endregion
        #region Commands
        [RelayCommand]
        public void CheckUsername() {
            if (Username.Length >= 6) {
                UsernameOK = true;
            } else {
                UsernameOK = false;
            }
        }
        [RelayCommand]
        public void CheckPassword() {
            if (Password.Length >= 6) {
                PasswordOK = true;
            } else {
                PasswordOK = false;
            }
        }
        [RelayCommand]
        public async void Login() {
            await Shell.Current.GoToAsync(nameof(MainPage)+$"?username={Username}&password={Password}");
        }
        #endregion
        #region Methods
        internal void Clean() {
            Password = ""; 
            Username = "";
            PasswordOK = UsernameOK = false;
        }
        #endregion
    }
}
