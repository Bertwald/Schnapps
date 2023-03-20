using Schnapps.Model;
using Schnapps.Services;

namespace Schnapps.View;
[QueryProperty(nameof(Username), "username")]
[QueryProperty(nameof(Password), "password")]
public partial class LoadingPage : ContentPage {

    #region Properties
    public string Username { get; set; }
    public string Password { get; set; }
    #endregion
    #region Constructors
    public LoadingPage() {
        InitializeComponent();
    }
    #endregion
    protected override async void OnNavigatedTo(NavigatedToEventArgs args) {
        if (await Authenticate()) {
            await Shell.Current.GoToAsync("///home");
        } else {
            await Shell.Current.GoToAsync(nameof(LoginPage) + $"?failedlogin=true");
        }
        base.OnNavigatedTo(args);
    }

    async Task<bool> Authenticate() {

        await Task.Delay(2000);

        User user = UserManager.GetUser(Username, Password);
        if (user is not null) {
            SessionData.GetInstance().User = user;
            return true;
        }
        return false;
    }

    protected override bool OnBackButtonPressed() {
        Application.Current.Quit();
        return true;
    }

}