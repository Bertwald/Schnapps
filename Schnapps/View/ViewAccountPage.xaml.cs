using Schnapps.Model;
using Schnapps.ViewModel;

namespace Schnapps.View;

public partial class ViewAccountPage : ContentPage
{
    #region Fields
    private SessionData sessionData;
    #endregion
    #region Constructors
    public ViewAccountPage()
	{
        sessionData = SessionData.GetInstance();
        InitializeComponent();
		BindingContext = new AccountViewModel(sessionData);
		Title = $"{sessionData.User?.Alias} Account";
	}
    #endregion
    #region Events
    protected override void OnNavigatedTo(NavigatedToEventArgs args) {
        var viewmodel = (AccountViewModel)BindingContext;
        viewmodel.UpdateViewModel();
        base.OnNavigatedTo(args);
    }
    #endregion
}