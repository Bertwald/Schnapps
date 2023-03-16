using Schnapps.ViewModel;
using YoutubeExplode.Channels;

namespace Schnapps.View;
[QueryProperty(nameof(FailedLogin), "failedlogin")]
public partial class LoginPage : ContentPage
{
    #region Fields
    private bool _failedLogin = false;
	#endregion
	#region Properties
	public bool FailedLogin { 
		get => _failedLogin; 
		set { 
			if 
				(_failedLogin != value) {
				_failedLogin = value; 
				OnPropertyChanged(); } 
		} 
	}
    #endregion
    #region Constructors
    public LoginPage(LoginViewModel loginViewModel)
	{
		BindingContext = loginViewModel;
		InitializeComponent();
	}
    #endregion
    protected override void OnNavigatedFrom(NavigatedFromEventArgs args) {
		((LoginViewModel)BindingContext).Clean();
        base.OnNavigatedFrom(args);
    }

	// This page has no visible back button navigation, this event will trigger when system back button is pressed.
	// It is reasonable to consider that an exit command (ie go back to the state when the app was not opened)
    protected override bool OnBackButtonPressed() {
        Application.Current.Quit();
        return true;
    }
}