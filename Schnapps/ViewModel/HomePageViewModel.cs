using CommunityToolkit.Mvvm.Input;
using Schnapps.Model;
using Schnapps.View;

namespace Schnapps.ViewModel {
    public partial class HomePageViewModel : BaseViewModel {
        #region Fields
        //private SessionData _sessionData = SessionData.GetInstance();
        #endregion
        #region Properties
        //public bool HasSavedRecipes { get => _sessionData.UserSavedData?.Any() ?? false; }
        #endregion
        #region Commands
        //No longer used means of navigation, replaced by flyout
        /*
        [RelayCommand]
        public void Redirect(string destination) {
            switch (destination) {
                case "logout":
                    _sessionData.CleanInstance();
                    Shell.Current.GoToAsync(nameof(LoginPage));
                    break;
                case nameof(ViewAccountPage):
                    Shell.Current.GoToAsync("///" + nameof(ViewAccountPage));
                    break;
                case nameof(SavedAndRatedPage):
                    Shell.Current.GoToAsync("///" + nameof(SavedAndRatedPage));
                    break;
                case nameof(BarSchoolPage):
                    Shell.Current.GoToAsync("///" + nameof(BarSchoolPage));
                    break;
                case nameof(SearchRecipePage):
                    Shell.Current.GoToAsync("///" + nameof(SearchRecipePage));
                    break;
            }
        }
        */
        #endregion
    }
}
