namespace SimpleMauiMVVM.Core
{
    /// <summary>
    /// Base class for a viewmodel class. The base class provides the <see cref="NotifyPropertyChangedBase"/> implementation
    /// Remember to mark the class with the <see cref="ViewModelAttribute"/>
    /// </summary>
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {
        private Visibility visibility;

        public ViewModelBase() {}

        public string Name => GetType().Name;

        public Visibility Visibility {
            get => visibility;
            private set
            {
                visibility = value;
                OnPropertyChanged();
            } 
        }

        public virtual void Show()
        {
            Visibility = Visibility.Visible;
        }

        public virtual void Hide()
        {
            Visibility = Visibility.Hidden;
        }

        public virtual void Collapse()
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
