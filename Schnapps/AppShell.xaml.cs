using CommunityToolkit.Mvvm.Input;
using Schnapps.Model;
using Schnapps.View;
using System.Reflection;

namespace Schnapps;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        // Now we can add methods to shell buttons
        BindingContext = this;

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
    }

    //Custom behavior to always navigate to the appshell item root
    protected override void OnNavigating(ShellNavigatingEventArgs args) {
        base.OnNavigating(args);
        // When changing shell content, remove all visited pages from stack
        if (args.Source == ShellNavigationSource.ShellSectionChanged) {
            var navigation = Shell.Current.Navigation;
            var pages = navigation.NavigationStack;
            for (var i = pages.Count - 1; i >= 1; i--) {
                navigation.RemovePage(pages[i]);
            }
        }
    }

    public RelayCommand LogoutCommand => new(async () => {
        if (await DisplayAlert("Logout", "You will be logged out", "Accept", "Cancel")) {
            SessionData.GetInstance().CleanInstance();
            await Shell.Current.GoToAsync("///login");
        }
    });
}
