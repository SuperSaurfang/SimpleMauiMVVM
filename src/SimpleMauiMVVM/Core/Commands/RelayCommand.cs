namespace SimpleMauiMVVM.Core.Commands
{
    /// <summary>
    /// Relay command that provides the base implementation of the command
    /// </summary>
    public class RelayCommand : CommandBase
    {
        public RelayCommand(Action<object>? execute, Predicate<object>? canExecute = null) 
            : base (execute, canExecute)
        { }
    }
}
