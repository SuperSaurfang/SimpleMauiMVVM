using SimpleMauiMVVM.Core;
using SimpleMauiMVVMExample.ViewModels;

namespace SimpleMauiMVVMExample.Views;

[Page]
public partial class UserEditorView : ContentPage
{
	public UserEditorView(UserEditorViewModel userEditorViewModel)
	{
        InitializeComponent();

        BindingContext = userEditorViewModel;
    }
}