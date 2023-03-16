using Schnapps.Model;
using Schnapps.Services;
using Schnapps.View;
using Schnapps.ViewModel;
using System.Xml.Linq;

namespace Schnapps;
    [QueryProperty(nameof(Username), "username")]
    [QueryProperty(nameof(Password), "password")]
public partial class MainPage : ContentPage
{
    #region Properties
    public string Username { get; set; }
    public string Password { get; set; }
    #endregion
    public MainPage() {
        InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args) {
        if (await Authenticate()) {
            await Shell.Current.GoToAsync("///home");
        } else {
            await Shell.Current.GoToAsync(nameof(LoginPage)+$"?failedlogin=true");
        }
        base.OnNavigatedTo(args);
    }

    async Task<bool> Authenticate() {

        await Task.Delay(2000);

        User user = UserManager.GetUser(Username, Password);
        if(user is not null) {
            SessionData.GetInstance().User=user;
            return true;
        }
        return false;
    }

    protected override bool OnBackButtonPressed() {
        Application.Current.Quit();
        return true;
    }

}

