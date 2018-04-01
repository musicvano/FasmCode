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

    }
}