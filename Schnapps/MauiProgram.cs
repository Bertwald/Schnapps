using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Schnapps.ViewModel;
using Schnapps.View;
using Schnapps.Services;

namespace Schnapps;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        #region Services
        builder.Services.AddSingleton<CocktailService>();
        #endregion
        #region Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddSingleton<BarSchoolPage>();
        builder.Services.AddSingleton<SearchRecipePage>();
        builder.Services.AddSingleton<SavedAndRatedPage>();
        builder.Services.AddSingleton<HomePage>();
        #endregion
        #region ViewModels
        builder.Services.AddSingleton<VideoViewModel>();
        builder.Services.AddSingleton<SavedAndRatedViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<SearchRecipesViewModel>();
        #endregion

        return builder.Build();
	}
}
