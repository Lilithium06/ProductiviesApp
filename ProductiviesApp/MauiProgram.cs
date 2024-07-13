using Microsoft.Extensions.Logging;
using ProductiviesApp.DataAccess;
using ProductiviesApp.Models;
using ProductiviesApp.ViewModels;
using ProductiviesApp.Views;

namespace ProductiviesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterAppServices()
                .RegisterViews()
                .RegisterViewModels()
                .RegisterModels()
                .RegisterDataAccess();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            _ = mauiAppBuilder.Services.AddSingleton<AppShell>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            _ = mauiAppBuilder.Services.AddTransient<MainPageViewModel>();
            _ = mauiAppBuilder.Services.AddTransient<QuestListViewModel>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            _ = mauiAppBuilder.Services.AddTransient<MainPage>();
            _ = mauiAppBuilder.Services.AddTransient<QuestListPage>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterModels(this MauiAppBuilder mauiAppBuilder)
        {
            _ = mauiAppBuilder.Services.AddTransient<PodoromoUnitModel>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterDataAccess(this MauiAppBuilder mauiAppBuilder)
        {
            _ = mauiAppBuilder.Services.AddSingleton<SkillsDatabase>();

            return mauiAppBuilder;
        }
    }


}
