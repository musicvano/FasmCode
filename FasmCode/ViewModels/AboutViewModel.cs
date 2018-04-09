using System.Reflection;

namespace FasmCode.ViewModels
{
    class AboutViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Copyright { get; set; }
        public string Version { get; set; }

        public AboutViewModel()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Title = assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            Copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            Version = "Version " +  assembly.GetName().Version.ToString();
        }
    }
}