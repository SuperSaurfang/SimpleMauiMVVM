using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            if (scopes.ContainsKey(scopeName))
            {
                var value = scopes[scopeName];
                if (value is Subject<TModel> subject)
                {
                    return subject;
                }
            }

            return null;
        }

        public void NextData<TModel>(TModel model) where TModel : new()
        {
            var scopeName = ResolveName<TModel>();
            if (!scopes.ContainsKey(scopeName)) return;

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
