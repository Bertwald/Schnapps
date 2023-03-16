using Schnapps.Services;
using Schnapps.ViewModel;

namespace Schnapps.View;

public partial class SearchRecipePage : ContentPage
{
    #region Constructors
    public SearchRecipePage(SearchRecipesViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
	#endregion
}