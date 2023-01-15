namespace SimpleMauiMVVM.Core.Commands
{
    /// <summary>
    /// If the command needs a parameter, the type of the parameter is always object, that is not very good,
    /// because you have to cast the object to your type. The Generic Parameter handles the type conversion for you
    /// and execute only if the conversion is successful
    /// </summary>
    /// <typeparam name="T">Generic type for strong typed command parameters</typeparam>
    public class RelayCommand<T> : CommandBase
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            if (parameter is T typedParameter) 
            {
                return CanExecute(typedParameter);
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            if(parameter is T typedParameter) 
            {
                Execute(typedParameter);
            }
        }

        public bool CanExecute(T parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(T parameter)
        {
            _execute(parameter);
        }
    }
}
