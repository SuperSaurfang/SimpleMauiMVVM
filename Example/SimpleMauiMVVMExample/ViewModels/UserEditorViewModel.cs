using SimpleMauiMVVM.Core;
using SimpleMauiMVVM.Services.ReactiveMessenger;
using SimpleMauiMVVMExample.Models;
using System.Reactive.Subjects;

namespace SimpleMauiMVVMExample.ViewModels
{
    [ViewModel]
    public class UserEditorViewModel : ViewModelBase
    {

        private string _userName;
        private string _userEmail;

        private readonly Subject<User> _userSubject;
        public UserEditorViewModel() 
        {
            _userSubject = new Subject<User>();
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

        public IObservable<User> User => _userSubject;

        private void PushUser()
        {
            var user = new User
            {
                Name = _userName,
                Email = _userEmail
            };

            _userSubject.OnNext(user);
        }
    }
}
