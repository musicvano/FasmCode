using System.ComponentModel;
using System.Windows;

namespace FasmCode.Models
{
    class Config
    {
        // Current keymap file
        public string Keymap { get; set; }

        // Current theme file
        public string Theme { get; set; }

        // If true the editor shows line numbers
        public bool ShowLineNumbers { get; set; }

        // Path from the root application folder to the compiler executable
        public string Compiler { get; set; }

        // X-coordinate of the main window
        public double Left { get; set; }

        // Y-coordinate of the main window
        public double Top { get; set; }

        // Width of the main window
        public double Width { get; set; }

        // Height of the main window
        public double Height { get; set; }

        // State of the main window
        public WindowState WindowState { get; set; }

        // Width of the tree view panel
        public double LeftPanelWidth { get; set; }

        // Height of the bootom output panel
        public double BottomPanelHeight { get; set; }
    }
}