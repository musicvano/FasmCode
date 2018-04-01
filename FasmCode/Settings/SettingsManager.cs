using FasmCode.Models;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Nett;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace FasmCode.Settings
{
    class SettingsManager
    {
        public const string SettingsFolder = "Settings";
        public const string ConfigFile = SettingsFolder + "/Config.toml";
        public const string KeymapFolder = SettingsFolder + "/Keymaps";
        public const string DefaultKeymap = KeymapFolder + "/Default.toml";
        public const string ThemeFolder = SettingsFolder + "/Themes";
        public const string DefaultTheme = ThemeFolder + "/Default.toml";

        public string RootFolder { get; set; }
        public Config Config { get; set; }
        public Keymap Keymap { get; set; }
        public Theme Theme { get; set; }
        public IHighlightingDefinition Highlighting { get; set; }

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
            using (XmlTextReader reader = new XmlTextReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("FasmCode.Syntax.Fasm.xshd")))
            {
                XshdSyntaxDefinition syntax = HighlightingLoader.LoadXshd(reader);
                foreach (var element in syntax.Elements)
                {
                    if (element is XshdColor)
                    {
                        var xshdColor = element as XshdColor;
                        switch (xshdColor.Name)
                        {
                            case "Comment":
                                break;
                            case "String":
                                break;
                            case "Number":
                                break;
                            case "SizeOperator":
                                break;
                            case "Register":
                                /*var c = (Color)ColorConverter.ConvertFromString("#FFFFFF00");
                                xshdColor.Background = new SimpleHighlightingBrush(c Color.FromScRgb(1.0f, 0.9f, 0.9f, 0.3f));*/
                                break;
                            case "Instruction":
                                break;
                            default:
                                break;
                        }
                    }
                }
                Highlighting = HighlightingLoader.Load(syntax, HighlightingManager.Instance);
            }
        }

        public void Save()
        {
            Toml.WriteFile(Config, Path.Combine(RootFolder, ConfigFile));
        }
    }
}