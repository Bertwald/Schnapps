using Schnapps.ViewModel;
using YoutubeExplode.Channels;

namespace Schnapps.View;
[QueryProperty(nameof(CanReturn), "canreturn")]
public partial class HomePage : ContentPage
{
    #region Fields
    private bool _canReturn;
	#endregion
	#region Properties
	public bool CanReturn {

		get => _canReturn;
		set {
			if
				(_canReturn != value) {
				_canReturn = value;
				OnPropertyChanged();
			}
		}
	}
    #endregion
    #region Constructors
    public HomePage(HomePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    #endregion
    #region Events
    // Disable back button to make it impossible to leave home page without using logout functionality
    protected override bool OnBackButtonPressed() {
		return true;
    }
	#endregion
}