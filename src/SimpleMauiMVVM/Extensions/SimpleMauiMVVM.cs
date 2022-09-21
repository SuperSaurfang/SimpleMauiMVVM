using SimpleMauiMVVM.Internals;
using SimpleMauiMVVM.Services.ReactiveMessenger;

namespace SimpleMauiMVVM.Extensions
{
    public static class SimpleMauiMVVMExtension
    {
        /// <summary>
        /// Adding the AppShell, MainPage, Views, ViewModels and the IMessengerService to the IoC Container.
        /// Only classes marked with the corresponding attribute are resolved and added to the IoC Container.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MauiAppBuilder UseSimpleMauiMVVM(this MauiAppBuilder builder) 
        {
            ConfigureServices(builder.Services);
            return builder;
        }

        private static void ConfigureServices(IServiceCollection services) 
        {
            services.AddSingleton<IReactiveMessengerService, ReactiveMessengerService>();
            
            services.AddComponents();
        }
    }
}
