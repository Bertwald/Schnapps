using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Schnapps.Model;
using Schnapps.Services;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Schnapps.ViewModel {
    public partial class DetailedPageViewModel : BaseViewModel {
        #region Fields
        private CocktailService _cocktailService;
        private SessionData _sessionData;
        private readonly YoutubeClient youtube = new();
        #endregion
        #region Properties
        [ObservableProperty]
        private Recipe observableRecipe;
        [ObservableProperty]
        private string currentCommand;
        [ObservableProperty]
        private RelayCommand executeSaveButtonCommand;
        #endregion
        #region Constructors
        public DetailedPageViewModel(CocktailService cocktailService, string id) {
            _sessionData = SessionData.GetInstance();
            _cocktailService = cocktailService;
            SetRecipeFromId(id);
        }
        #endregion
        #region Commands
        [RelayCommand]
        public async void RandomNew() {
            string newId = (await _cocktailService.CocktailDBSevice.GetRandomCocktailAsync()).Drinks.FirstOrDefault().IdDrink;
            SetRecipeFromId(newId);
        }
        #endregion
        #region Methods
        private async void SetRecipeFromId(string drinkId) {
            var drink = (await _cocktailService.CocktailDBSevice.GetCocktailByIdAsync(drinkId)).Drinks.SingleOrDefault();
            Recipe newRecipe = new() {
                DrinkId = drink.IdDrink,
                DrinkName = drink.StrDrink,
                Imageurl = drink.StrImageSource ?? drink.StrDrinkThumb,
                Instructions = drink.StrInstructions,
                VideoURL = drink.StrVideo ?? "",
                Ingredients = new List<string>() {
                    drink.StrMeasure1 + " " + drink.StrIngredient1,
                    drink.StrMeasure2 + " " + drink.StrIngredient2,
                    drink.StrMeasure3 + " " + drink.StrIngredient3,
                    drink.StrMeasure4 + " " + drink.StrIngredient4,
                    drink.StrMeasure5 + " " + drink.StrIngredient5,
                    drink.StrMeasure6 + " " + drink.StrIngredient6,
                    drink.StrMeasure7 + " " + drink.StrIngredient7,
                    drink.StrMeasure8 + " " + drink.StrIngredient8,
                    drink.StrMeasure9 + " " + drink.StrIngredient9,
                    drink.StrMeasure10 + " " + drink.StrIngredient10,
                    drink.StrMeasure11 + " " + drink.StrIngredient11,
                    drink.StrMeasure12 + " " + drink.StrIngredient12,
                    drink.StrMeasure13 + " " + drink.StrIngredient13,
                    drink.StrMeasure14 + " " + drink.StrIngredient14,
                    drink.StrMeasure15 + " " + drink.StrIngredient15 },
                IsAlcoholic = drink.StrAlcoholic == "Alcoholic"
            };
            // Purge List from the strange empty placeholders supplied by the api
            newRecipe.Ingredients.RemoveAll(x => x == " " || x is null);
            // If video url is a youtube video, get the correct url for mediaelement
            if (newRecipe.VideoURL.Contains("youtu")) {
                newRecipe.VideoURL = await GetStreamAsync(newRecipe.VideoURL);
            }
            ObservableRecipe = newRecipe;
            SetSaveButtonCommand();
        }
        // Method to check off requirement for anonymous delegate methods
        public void SetSaveButtonCommand() {
            if (_sessionData.UserSavedData.Select(x => x.DrinkId).Contains(ObservableRecipe.DrinkId)) {
                CurrentCommand = "Remove from Saved Favorites";
                ExecuteSaveButtonCommand = new RelayCommand((delegate {
                    _sessionData.UserSavedData.RemoveAll(x => x.DrinkId == ObservableRecipe.DrinkId);
                    SetSaveButtonCommand();
                }));
            } else {
                CurrentCommand = "Save To favorites";
                ExecuteSaveButtonCommand = new RelayCommand((delegate {
                    _sessionData.UserSavedData.Add(ObservableRecipe);
                    SetSaveButtonCommand();
                }));
            }
        }

        public async Task<string> GetStreamAsync(string url) =>
                          (await youtube.Videos.Streams.GetManifestAsync(url))
                          .GetMuxedStreams()
                          .GetWithHighestVideoQuality()?
                          .Url;
        #endregion
    }
}
