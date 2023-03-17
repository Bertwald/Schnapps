using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using Schnapps.Model;
using System.Collections.ObjectModel;

namespace Schnapps.ViewModel {
    public partial class AccountViewModel : BaseViewModel {
        #region Fields
        private SessionData sessionData;
        #endregion
        #region Properties
        [ObservableProperty]
        private ObservableCollection<Recipe> recipes = new();
        [ObservableProperty]
        private User userData;
        #endregion
        #region Constructors
        internal AccountViewModel(SessionData data) {
            sessionData = data;
            data.UserSavedData?.ForEach(x => recipes.Add(x));
            UserData = data.User;
        }
        #endregion
        #region Methods
        internal void UpdateViewModel() {
            ResetRecipesList();
        }
        private void ResetRecipesList() {
            Recipes = sessionData.UserSavedData.ToObservableCollection();
        }
        #endregion
    }
}
