using SimpleMauiMVVM.Core;
using SimpleMauiMVVMExample.ViewModels;

namespace SimpleMauiMVVMExample
{
    [Page]
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();

            BindingContext = mainPageViewModel;
        }
    }
}