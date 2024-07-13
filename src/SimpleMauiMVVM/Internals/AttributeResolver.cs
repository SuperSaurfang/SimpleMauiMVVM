using Microsoft.Extensions.DependencyInjection;
using SimpleMauiMVVM.Core;
using System.Reflection;

namespace SimpleMauiMVVM.Internals
{
    internal static class AttributeResolver
    {
        public static void AddComponents(this IServiceCollection services) 
        {
            List<Type> targetAttributes =
            [
                typeof(PageAttribute),
                typeof(AppShellAttribute),
                typeof(ViewModelAttribute)
            ];
            RegisterClasses(services, targetAttributes);
        }

        private static void RegisterClasses(IServiceCollection services, List<Type> targetAttributes)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                var types = assembly.GetTypes();
                var correctTypes = types.Where(p => FindCorrectType(p, targetAttributes));
                if (!correctTypes.Any()) 
                {
                    continue;
                }

                foreach (Type type in correctTypes)
                {
                    services.AddTransient(type);
                }
            }
        }

        private static bool FindCorrectType(Type type, List<Type> targetAttributes)
        {
            List<object> attributes = type.GetCustomAttributes(true).ToList();
            List<object> result = attributes.FindAll(p => targetAttributes.Exists(t => t.IsEquivalentTo(p.GetType())));
            return result.Count > 0;
        }
    }
}
