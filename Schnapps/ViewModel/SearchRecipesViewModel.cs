using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Schnapps.Model;
using Schnapps.Services;
using Schnapps.View;
using System.Collections.ObjectModel;


namespace Schnapps.ViewModel {
    public partial class SearchRecipesViewModel : BaseViewModel {
        #region Fields
        private CocktailService _cocktailService;
        #endregion
        #region Properties
        [ObservableProperty]
        private string chosenItem;
        [ObservableProperty]
        private ObservableCollection<DisplayItem> drinks = new();
        [ObservableProperty]
        private string searchstring;
        [ObservableProperty]
        private ObservableCollection<string> ingredients = new();
        #endregion
        #region Constructors
        public SearchRecipesViewModel(CocktailService cocktailService) {
            _cocktailService = cocktailService;
            FillInitialList();
        }
        #endregion
        #region Methods
        private async void FillInitialList() { 
            var cocktails = await _cocktailService.CocktailDBSevice.GetRandomCocktailAsync();
            cocktails.Drinks.ToList().ForEach(x => Drinks.Add(new DisplayItem() { Id = x.IdDrink, Name = x.StrDrink, Thumbnail = x.StrDrinkThumb }));
            var ingredients = await _cocktailService.CocktailDBSevice.GetAllIngredientsAsync();
            ingredients.Drinks.OrderBy(x => x.StrIngredient1).ToList().ForEach(x => Ingredients.Add(x.StrIngredient1));
        }
        #endregion
        #region Commands
        [RelayCommand]
        public async void MakeSelection() {
            var cocktails = await _cocktailService.CocktailDBSevice.GetCocktailsByIngredientAsync(ChosenItem??"Vodka");
            Drinks.Clear();
            cocktails.Drinks.ToList().ForEach(x => Drinks.Add(new DisplayItem() { Id = x.IdDrink, Name = x.StrDrink, Thumbnail = x.StrDrinkThumb }));
        }

        [RelayCommand]
        public async void ShowDetails(DisplayItem item) {
            if (item is DisplayItem p) {
                await Shell.Current.GoToAsync($"/{nameof(DetailsPage)}?DetailId={p.Id}");
            }
        }

        [RelayCommand]
        public async void OrderResults() {

        }
        #endregion
    }
}
