using Schnapps.View;
using Schnapps.ViewModel;

namespace Schnapps;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        MainPage = new AppShell();
    }
}
