using SimpleMauiMVVM.Core;
using SimpleMauiMVVM.Services.ReactiveMessenger;
using SimpleMauiMVVMExample.Models;

namespace SimpleMauiMVVMExample.ViewModels
{
    [ViewModel]
    public class UserEditorViewModel : ViewModelBase
    {

        private string _userName;
        private string _userEmail;

        private readonly IReactiveMessengerService _messengerService;
        public UserEditorViewModel(IReactiveMessengerService messengerService) 
        {
            _messengerService = messengerService;
        }

        public string UserName 
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
                PushUser();
            }
        }
        public string UserEmail 
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                OnPropertyChanged();
                PushUser();
            }
        }

        private void PushUser()
        {
            var user = new User
            {
                Name = _userName,
                Email = _userEmail
            };

            _messengerService.NextData(user);
        }
    }
}
