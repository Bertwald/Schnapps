using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Schnapps.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schnapps.ViewModel {
    public partial class SavedAndRatedViewModel: BaseViewModel {
        #region Members
        private SessionData _sessionData;
        #endregion
        #region Properties
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RatingString))]
        private double rating;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Rating))]
        private Recipe currentlyRating = new();
        [ObservableProperty]
        private ObservableCollection<Recipe> _recipes;
        public string RatingString { get => ((Rating)Rating).ToString(); }
        #endregion
        #region Contructors
        public SavedAndRatedViewModel() {
            _sessionData = SessionData.GetInstance();
            UpdateObservables();
        }
        #endregion
        #region Commands
        [RelayCommand]
        public async void MakeSelection() {
            await Task.Run(() => Rating = (double)(CurrentlyRating?.Rating??Model.Rating.None));
        }
        [RelayCommand]
        public async void Rate() {
            CurrentlyRating.Rating = (Rating)Rating;
        }
        #endregion
        #region Methods
        internal void UpdateObservables() {
            Recipes= _sessionData.UserSavedData.ToObservableCollection();
            CurrentlyRating = Recipes.FirstOrDefault();
        }
        #endregion
    }
}
