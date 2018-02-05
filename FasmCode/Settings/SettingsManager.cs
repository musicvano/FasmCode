using FasmCode.Models;
using Nett;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FasmCode.Settings
{
    class SettingsManager
    {
        public const string SettingsFolder = "Settings";
        public const string ConfigFile = SettingsFolder + "/Config.toml";
        public const string KeymapFolder = SettingsFolder + "/Keymaps";
        public const string DefaultKeymap = KeymapFolder + "/Fasm Code.toml";
        public const string ThemeFolder = SettingsFolder + "/Themes";
        public const string DefaultTheme = ThemeFolder + "/Fasm Code.toml";

        public string RootFolder { get; set; }
        public Config Config { get; set; }
        public Keymap Keymap { get; set; }
        public Theme Theme { get; set; }

        // Return a root folder of current project. Is used for design-time operations (WPF xaml editor)
        string ProjectRootFolder([CallerFilePath] string from = null) =>
            Directory.GetParent(from).Parent.FullName;

        public SettingsManager()
        {
            RootFolder = DesignerProperties.GetIsInDesignMode(new DependencyObject()) 
                ? ProjectRootFolder()
                : Directory.GetCurrentDirectory();
            Config = Toml.ReadFile<Config>($"{RootFolder}/{ConfigFile}");
            Keymap = Toml.ReadFile<Keymap>($"{RootFolder}/{KeymapFolder}/{Config.Keymap}.toml");
            Theme = Toml.ReadFile<Theme>($"{RootFolder}/{ThemeFolder}/{Config.Theme}.toml");
        }
    }
}