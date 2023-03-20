using Schnapps.Services;
using Schnapps.ViewModel;
using System.Runtime.CompilerServices;

namespace Schnapps.View;

[QueryProperty(nameof(DetailId), nameof(DetailId))]
public partial class DetailsPage : ContentPage
{
    #region Fields
    private ICocktailService _service;
    #endregion
    #region Properties
    public string DetailId { set => SetBinding(value); }
    #endregion
    #region Constructors
    public DetailsPage(ICocktailService cocktailService)
	{
		InitializeComponent();
		_service = cocktailService;
	}
    #endregion
    #region Methods
    private void SetBinding(string id) {
		BindingContext = new DetailedPageViewModel(_service, id);
    }
    #endregion
}