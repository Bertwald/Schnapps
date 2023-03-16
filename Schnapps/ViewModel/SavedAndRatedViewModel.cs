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
        private SessionData _sessionData;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(RatingString))]
        private double rating;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Rating))]
        private Recipe currentlyRating = new();
        [ObservableProperty]
        private ObservableCollection<Recipe> _recipes;
        public string RatingString { get => ((Rating)Rating).ToString(); }


        public SavedAndRatedViewModel() {
            _sessionData = SessionData.GetInstance();
            UpdateObservables();
        }

        [RelayCommand]
        public async void MakeSelection() {
            await Task.Run(() => Rating = (double)(CurrentlyRating?.Rating??Model.Rating.None));
        }
        [RelayCommand]
        public async void Rate() {
            CurrentlyRating.Rating = (Rating)Rating;
        }

        internal void UpdateObservables() {
            Recipes= _sessionData.UserSavedData.ToObservableCollection();
            CurrentlyRating = Recipes.FirstOrDefault();
        }

    }
}
