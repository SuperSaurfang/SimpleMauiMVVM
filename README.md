![Build Status](https://dev.azure.com/radiergummi90/SimpleMauiMVVM/_apis/build/status%2FSuperSaurfang.SimpleMauiMVVM?branchName=master)

# SimpleMauiMVVM

Simple MAUI MVVM is a MVVM Framework for .Net Maui. It provide some simple stuff to enable MVVM in your .Net Maui Project.

## Installation

```powershell
dotnet add package SimpleMauiMVVM --version 1.0.159
```

Or via nuget manager in Visual Studio or Rider

## How to use

Add the 'ViewModel' attribute to your ViewModel

```csharp
[ViewModel]
public class MainPageViewModel : ViewModelBase
{
  ...
}
```

Add the 'Page' attribute to the content page and inject the MainPageViewModel into the MainPage

```csharp
[Page]
public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel mainPageViewModel)
    {
        InitializeComponent();

        BindingContext = mainPageViewModel;
    }
}
```

At least call the extension method to enable the Simple Maui MVVM Framework.
```csharp
 return builder
	.UseSimpleMauiMVVM()
```

Every class with the matching attribute will be registered into the DI Container.

There is also a messanger service available you can use. Just inject the interface 'IReactiveMessengerService' 
into the service or view model. 

The class 'ViewModelBase' provide a default implementation of the 'INotifyPropertyChanged' so you don't need to implement again this interface.
In Fact 'ViewModelBase' inherit from 'NotifyPropertyChangedBase' which provide the implementation.

