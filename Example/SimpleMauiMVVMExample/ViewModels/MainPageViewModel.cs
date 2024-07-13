using SimpleMauiMVVM.Core;
using SimpleMauiMVVM.Core.Commands;
using SimpleMauiMVVM.Services.ReactiveMessenger;
using SimpleMauiMVVMExample.Models;
using System.Windows.Input;

namespace SimpleMauiMVVMExample.ViewModels
{
    [ViewModel]
    public class MainPageViewModel : ViewModelBase
    {
        private int _count = 0;
        private User? _user;

        private readonly RelayCommand _increaseCommand;
        public MainPageViewModel(IReactiveMessengerService messengerService)
        {
            _increaseCommand = new RelayCommand(a => Increase());

            messengerService.OnData<User>()!.Subscribe(user => User = user);
        }

        public string IncreaseText 
        {
            get 
            {
                if (_count > 1)
                    return $"Clicked {_count} times";
                return $"Clicked {_count} time";
            }
        }

        public User? User 
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public ICommand IncreaseCommand => _increaseCommand;

        private void Increase()
        {
            _count++;
            OnPropertyChanged(nameof(IncreaseText));
        }
    }
}
