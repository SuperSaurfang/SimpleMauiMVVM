using System.Runtime.CompilerServices;

namespace SimpleMauiMVVM.Core
{
    /// <summary>
    /// Marks a class as ViewModel that can be registered in the DI Container
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewModelAttribute : Attribute { }

    /// <summary>
    /// Marks a class as the Shell that can be registered in the DI Container. Should only be once?
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AppShellAttribute : Attribute { }

    /// <summary>
    /// Marks a class as the Page that can be registered in the DI Container. Should used for all the others Contentpages
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class PageAttribute : Attribute { }
}
