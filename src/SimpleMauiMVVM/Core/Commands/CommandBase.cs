using System.Windows.Input;

namespace SimpleMauiMVVM.Core.Commands
{
    public abstract class CommandBase : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public CommandBase() { }

        public CommandBase(Action<object> execute, Predicate<object> canExecute) 
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public virtual void Execute(object parameter)
        {
            execute(parameter);
        }

        public virtual void Invalidate()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}