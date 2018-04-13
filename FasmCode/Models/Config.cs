using System.Windows;

namespace FasmCode.Models
{
    /// <summary>
    /// Configurations of the application
    /// </summary>
    class Config
    {
        /// <summary>
        /// Current keymap file without extention
        /// </summary>
        public string Keymap { get; set; }

        /// <summary>
        /// Current theme file without extention
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// If true the editor shows line numbers
        /// </summary>
        public bool ShowLineNumbers { get; set; }

        /// <summary>
        /// Path from the root application folder to the compiler executable
        /// </summary>
        public string Compiler { get; set; }

        /// <summary>
        /// X-coordinate of the main window
        /// </summary>
        public double Left { get; set; }

        /// <summary>
        /// Y-coordinate of the main window
        /// </summary>
        public double Top { get; set; }

        /// <summary>
        /// The width of the main window
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// The height of the main window
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// State of the main window
        /// </summary>
        public WindowState WindowState { get; set; }

        /// <summary>
        /// The width of the tree view panel
        /// </summary>
        public double LeftPanelWidth { get; set; }

        /// <summary>
        /// The height of the bootom output panel
        /// </summary>
        public double BottomPanelHeight { get; set; }
    }
}