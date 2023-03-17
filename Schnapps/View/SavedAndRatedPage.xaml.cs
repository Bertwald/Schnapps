using Schnapps.ViewModel;

namespace Schnapps.View;

public partial class SavedAndRatedPage : ContentPage
{
    #region Constructors
    // PATTERN: dependency injection, handled automagically by the builder if
    // we have registered models and services as singletons
    public SavedAndRatedPage(SavedAndRatedViewModel savedAndRatedViewModel)
	{
		InitializeComponent();
		BindingContext=savedAndRatedViewModel;
	}
    #endregion
    #region Events
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e) {
		ratingGrid.Children.Clear();
        for (int i = 0; i < (int)e.NewValue; i++) {
            ratingGrid.Add(new Image { Source = ImageSource.FromFile("beericon.png") }, i, 0);
        }
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args) {
        var viewmodel = (SavedAndRatedViewModel)BindingContext;
        viewmodel.UpdateObservables();
        base.OnNavigatedTo(args);
    }
    private void ConformRating(object sender, EventArgs e) {
		DisplayAlert("Rating", "Your rating has been saved", "OK");
    }
    #endregion
}