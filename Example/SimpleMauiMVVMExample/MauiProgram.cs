using SimpleMauiMVVM.Extensions;

namespace SimpleMauiMVVMExample
{
    public class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            return builder
                .UseSimpleMauiMVVM()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .Build();
        }
    }
}