using System.Windows.Input;

namespace SimpleMauiMVVM.Core.Commands
{
    public abstract class CommandBase : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public CommandBase() { }

        public CommandBase(Action<object> execute, Predicate<object> canExecute) 
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public virtual void Execute(object parameter)
        {
            _execute(parameter);
        }

        public virtual void Invalidate()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}