using Foundation;
using SimpleMauiMVVM;

namespace SimpleMauiMVVMExample
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}