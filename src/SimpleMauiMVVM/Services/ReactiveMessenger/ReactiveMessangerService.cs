using System.Reactive.Subjects;

namespace SimpleMauiMVVM.Services.ReactiveMessenger
{
    public class ReactiveMessengerService : IReactiveMessengerService
    {
        private readonly Dictionary<string, object> scopes;

        public ReactiveMessengerService() 
        {
            scopes = new Dictionary<string, object>
            {
                { nameof(Object), new Subject<dynamic>() }
            };
        }

        public IObservable<TModel> OnData<TModel>() where TModel : new()
        {
            var scopeName = ResolveName<TModel>();
            if(!scopes.ContainsKey(scopeName))
            {
                CreateScope<TModel>();
            }
            
            var value = scopes[scopeName];
            return value as Subject<TModel>;
        }

        public void NextData<TModel>(TModel model) where TModel : new()
        {
            var scopeName = ResolveName<TModel>();
            if (!scopes.ContainsKey(scopeName))
            {
                CreateScope<TModel>();
            };

            var value = scopes[scopeName];
            if(value is Subject<TModel> subject)
            {
                subject.OnNext(model);
            }
        }

        public void CreateScope<TModel>() where TModel : new()
        {
            var scopeName = ResolveName<TModel>();
            if (!scopes.ContainsKey(scopeName)) 
            {
                var subject = new Subject<TModel>();
                scopes[scopeName] = subject;
            }
        }

        public void DeleteScope<TModel>() where TModel : new()
        {
            var scopeName = ResolveName<TModel>();
            if (!scopes.ContainsKey(scopeName) || scopeName.Equals(nameof(Object))) return;
            
            var value = scopes[scopeName];
            if(value is Subject<TModel> subject)
            {
                subject.OnCompleted();
                subject.Dispose();
            }
            scopes.Remove(scopeName);
        }

        private static string ResolveName<TModel>() where TModel : new()
        {
            var model = new TModel();
            var type = model.GetType();
            return type.Name;
        }
    }
}
