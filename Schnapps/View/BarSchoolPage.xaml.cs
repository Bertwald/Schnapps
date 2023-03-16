using Schnapps.ViewModel;
using YoutubeExplode;
namespace Schnapps.View;

public partial class BarSchoolPage : ContentPage
{
    #region Constructors
    public BarSchoolPage(VideoViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
    #endregion
}