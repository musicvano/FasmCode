using System.Reflection;

namespace FasmCode.ViewModels
{
    /// <summary>
    /// Represents an about information
    /// </summary>
    class AboutViewModel
    {
        /// <summary>
        /// Creates a new instance of AboutViewModel
        /// </summary>
        public AboutViewModel()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Title = assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            Copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            Version = "Version " +  assembly.GetName().Version.ToString();
        }

        /// <summary>
        /// The title of the application
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The brief description of the application
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The information about the copyright
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// The information about the version
        /// </summary>
        public string Version { get; set; }
    }
}