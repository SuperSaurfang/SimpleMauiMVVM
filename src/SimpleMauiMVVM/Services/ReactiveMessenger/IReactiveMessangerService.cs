namespace SimpleMauiMVVM.Services.ReactiveMessenger
{
    /// <summary>
    /// An simple reactive strong typed messenger service which allow you send between services/view models and other services/view models
    /// 
    /// Each model class represent his own scope
    /// </summary>
    public interface IReactiveMessengerService
    {
        /// <summary>
        /// Create a new scope based on the model class
        /// 
        /// Note: it is not necessary to call this, if you call <see cref="NextData{TModel}(TModel)"/> or <see cref="OnData{TModel}"/> a scope be will automaticaly created
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        public void CreateScope<TModel>() where TModel : new();
        
        /// <summary>
        /// Delete the scope, before the scope will be deleted a clompleted will be send to the subscribers
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        public void DeleteScope<TModel>() where TModel : new();
        
        /// <summary>
        /// Push data to the subscribers, if the model is not present in the scope a new one will be created
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model"></param>
        public void NextData<TModel>(TModel model) where TModel : new();
        
        /// <summary>
        /// Returns an observable to subscribe and receive data. If the model is not present in the scope a new one will be created
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public IObservable<TModel> OnData<TModel>() where TModel : new();

    }
}
