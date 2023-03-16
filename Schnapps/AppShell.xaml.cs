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

		//Routing.RegisterRoute(nameof(BarSchoolPage), typeof(BarSchoolPage));
  //      Routing.RegisterRoute(nameof(GetVariationsPage), typeof(GetVariationsPage));
  //      Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
  //      Routing.RegisterRoute(nameof(NonAlcoholicPage), typeof(NonAlcoholicPage));
  //      Routing.RegisterRoute(nameof(SavedAndRatedPage), typeof(SavedAndRatedPage));
  //      Routing.RegisterRoute(nameof(SearchRecipePage), typeof(SearchRecipePage));
  //      Routing.RegisterRoute(nameof(ViewAccountPage), typeof(ViewAccountPage));
  //      Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
    }

    //Custom behavior to always navigate to the appshell item root
    protected override void OnNavigating(ShellNavigatingEventArgs args) {
        base.OnNavigating(args);
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
