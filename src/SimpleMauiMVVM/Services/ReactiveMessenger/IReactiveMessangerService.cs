using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMauiMVVM.Services.ReactiveMessenger
{
    public interface IReactiveMessengerService
    {
        public void CreateScope<TModel>() where TModel : new();
        public void DeleteScope<TModel>() where TModel : new();
        public void NextData<TModel>(TModel model) where TModel : new();
        public IObservable<TModel> OnData<TModel>() where TModel : new();

    }
}
