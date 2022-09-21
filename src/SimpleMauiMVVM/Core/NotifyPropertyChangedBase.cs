using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleMauiMVVM.Core
{
    /// <summary>
    /// Base implementation of the <see cref="INotifyPropertyChanged"/> Interface 
    /// </summary>
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
