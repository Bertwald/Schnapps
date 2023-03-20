using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Schnapps.ViewModel;
using Schnapps.View;
using Schnapps.Services;
using Refit;
using Microsoft.Maui.Hosting;

namespace Schnapps;

public static class MauiProgram
{

    private const string _host = "https://www.thecocktaildb.com/api/json";
    private const string _version = "v1";
    private const string _key = "1";
    private const string _fullUrl = $"{_host}/{_version}/{_key}/";

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
        #region ComponentInit
            .UseMauiCommunityToolkitMediaElement()
            .UseMauiCommunityToolkit()
        #endregion
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif



        #region Services
        builder.Services.AddRefitClient<ICocktailService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(_fullUrl));
        #endregion
        #region Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<LoadingPage>();
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
