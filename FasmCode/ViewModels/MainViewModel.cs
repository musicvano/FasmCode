using FasmCode.Commands;
using FasmCode.Settings;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

namespace FasmCode.ViewModels
{
    class MainViewModel
    {
        public MainWindow Window { get; set; }
        public SettingsManager Settings { get; set; }
        public ICommand WindowLoaded { get; set; }

        public ICommand NewCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand OpenFolderCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand SaveAllCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand CloseFolderCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public ICommand UndoCommand { get; set; }
        public ICommand RedoCommand { get; set; }
        public ICommand CutCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand PasteCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectAllCommand { get; set; }
        public ICommand FindCommand { get; set; }
        public ICommand ReplaceCommand { get; set; }

        public ICommand CompileCommand { get; set; }
        public ICommand RunCommand { get; set; }

        public ICommand TerminalCommand { get; set; }
        public ICommand CalculatorCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        public ICommand HelpCommand { get; set; }
        public ICommand AboutCommand { get; set; }

        public InputBindingCollection KeyBindings { get; set; }

        public MainViewModel()
        {
            Settings = new SettingsManager();
            CreateCommands();
            CreateKeyBindings();
        }

        private void CreateCommands()
        {
            WindowLoaded = new RelayCommand(WindowLoadedExecute, () => true);
            NewCommand = new RelayCommand(NewExecute, NewCanExecute);
            OpenCommand = new RelayCommand(OpenExecute, OpenCanExecute);
            OpenFolderCommand = new RelayCommand(OpenFolderExecute, OpenFolderCanExecute);
            SaveCommand = new RelayCommand(SaveExecute, SaveCanExecute);
            SaveAsCommand = new RelayCommand(SaveAsExecute, SaveAsCanExecute);
            SaveAllCommand = new RelayCommand(SaveAllExecute, SaveAllCanExecute);
            CloseCommand = new RelayCommand(CloseExecute, CloseCanExecute);
            CloseFolderCommand = new RelayCommand(CloseFolderExecute, CloseFolderCanExecute);
            ExitCommand = new RelayCommand(ExitExecute, ExitCanExecute);

            UndoCommand = new RelayCommand(UndoExecute, UndoCanExecute);
            RedoCommand = new RelayCommand(RedoExecute, RedoCanExecute);
            CutCommand = new RelayCommand(CutExecute, CutCanExecute);
            CopyCommand = new RelayCommand(CopyExecute, CopyCanExecute);
            PasteCommand = new RelayCommand(PasteExecute, PasteCanExecute);
            DeleteCommand = new RelayCommand(DeleteExecute, DeleteCanExecute);
            SelectAllCommand = new RelayCommand(SelectAllExecute, SelectAllCanExecute);
            FindCommand = new RelayCommand(FindExecute, FindCanExecute);
            ReplaceCommand = new RelayCommand(ReplaceExecute, ReplaceCanExecute);

            CompileCommand = new RelayCommand(CompileExecute, CompileCanExecute);
            RunCommand = new RelayCommand(RunExecute, RunCanExecute);

            TerminalCommand = new RelayCommand(TerminalExecute, TerminalCanExecute);
            CalculatorCommand = new RelayCommand(CalculatorExecute, CalculatorCanExecute);
            SettingsCommand = new RelayCommand(SettingsExecute, SettingsCanExecute);

            HelpCommand = new RelayCommand(HelpExecute, HelpCanExecute);
            AboutCommand = new RelayCommand(AboutExecute, AboutCanExecute);
        }

        private void CreateKeyBindings()
        {
            KeyGestureConverter converter = new KeyGestureConverter();
            KeyBindings = new InputBindingCollection()
            {
                new KeyBinding(NewCommand, converter.ConvertFromString(Settings.Keymap.New) as KeyGesture),
                new KeyBinding(OpenCommand, converter.ConvertFromString(Settings.Keymap.Open) as KeyGesture),
                new KeyBinding(OpenFolderCommand, converter.ConvertFromString(Settings.Keymap.OpenFolder) as KeyGesture),
                new KeyBinding(SaveCommand, converter.ConvertFromString(Settings.Keymap.Save) as KeyGesture),
                new KeyBinding(SaveAsCommand, converter.ConvertFromString(Settings.Keymap.SaveAs) as KeyGesture),
                new KeyBinding(SaveAllCommand, converter.ConvertFromString(Settings.Keymap.SaveAll) as KeyGesture),
                new KeyBinding(CloseCommand, converter.ConvertFromString(Settings.Keymap.Close) as KeyGesture),
                new KeyBinding(CloseFolderCommand, converter.ConvertFromString(Settings.Keymap.CloseFolder) as KeyGesture),
                new KeyBinding(ExitCommand, converter.ConvertFromString(Settings.Keymap.Exit) as KeyGesture),

                new KeyBinding(UndoCommand, converter.ConvertFromString(Settings.Keymap.Undo) as KeyGesture),
                new KeyBinding(RedoCommand, converter.ConvertFromString(Settings.Keymap.Redo) as KeyGesture),
                new KeyBinding(CutCommand, converter.ConvertFromString(Settings.Keymap.Cut) as KeyGesture),
                new KeyBinding(CopyCommand, converter.ConvertFromString(Settings.Keymap.Copy) as KeyGesture),
                new KeyBinding(PasteCommand, converter.ConvertFromString(Settings.Keymap.Paste) as KeyGesture),
                new KeyBinding(DeleteCommand, converter.ConvertFromString(Settings.Keymap.Delete) as KeyGesture),
                new KeyBinding(SelectAllCommand, converter.ConvertFromString(Settings.Keymap.SelectAll) as KeyGesture),
                new KeyBinding(FindCommand, converter.ConvertFromString(Settings.Keymap.Find) as KeyGesture),
                new KeyBinding(ReplaceCommand, converter.ConvertFromString(Settings.Keymap.Replace) as KeyGesture),

                new KeyBinding(CompileCommand, converter.ConvertFromString(Settings.Keymap.Compile) as KeyGesture),
                new KeyBinding(RunCommand, converter.ConvertFromString(Settings.Keymap.Run) as KeyGesture),

                new KeyBinding(TerminalCommand, converter.ConvertFromString(Settings.Keymap.Terminal) as KeyGesture),
                new KeyBinding(CalculatorCommand, converter.ConvertFromString(Settings.Keymap.Calculator) as KeyGesture),
                new KeyBinding(SettingsCommand, converter.ConvertFromString(Settings.Keymap.Settings) as KeyGesture),

                new KeyBinding(HelpCommand, converter.ConvertFromString(Settings.Keymap.Help) as KeyGesture),
                new KeyBinding(AboutCommand, converter.ConvertFromString(Settings.Keymap.About) as KeyGesture)
            };
        }

        private void WindowLoadedExecute()
        {
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
                                var c = (Color)ColorConverter.ConvertFromString("#FFFFFF00");
                                xshdColor.Background = new SimpleHighlightingBrush(c /*Color.FromScRgb(1.0f, 0.9f, 0.9f, 0.3f)*/);
                                break;
                            case "Instruction":
                                break;
                            default:
                                break;
                        }                        
                    }
                }
                Window.textEditor.SyntaxHighlighting = HighlightingLoader.Load(syntax, HighlightingManager.Instance);
            }
        }

        private void NewExecute()
        {

        }

        private bool NewCanExecute() => true;

        private void OpenExecute()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private bool OpenCanExecute() => true;

        private void OpenFolderExecute()
        {
            
        }

        private bool OpenFolderCanExecute() => true;

        private void SaveExecute()
        {

        }

        private bool SaveCanExecute() => true;

        private void SaveAsExecute()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private bool SaveAsCanExecute() => true;
        
        private void SaveAllExecute()
        {

        }

        private bool SaveAllCanExecute() => true;

        private void CloseExecute()
        {

        }

        private bool CloseCanExecute() => true;
        
        private void CloseFolderExecute()
        {

        }

        private bool CloseFolderCanExecute() => true;
        
        private void ExitExecute()
        {

        }

        private bool ExitCanExecute() => true;

        private void UndoExecute()
        {

        }

        private bool UndoCanExecute() => true;

        private void RedoExecute()
        {

        }

        private bool RedoCanExecute() => true;

        private void CutExecute()
        {

        }

        private bool CutCanExecute() => true;

        private void CopyExecute()
        {
            
        }

        private bool CopyCanExecute() => true;

        private void PasteExecute()
        {

        }

        private bool PasteCanExecute() => true;

        private void DeleteExecute()
        {

        }

        private bool DeleteCanExecute() => true;

        private void SelectAllExecute()
        {

        }

        private bool SelectAllCanExecute() => true;

        private void FindExecute()
        {

        }

        private bool FindCanExecute() => true;

        private void ReplaceExecute()
        {

        }

        private bool ReplaceCanExecute() => true;

        private void CompileExecute()
        {

        }

        private bool CompileCanExecute() => true;

        private void RunExecute()
        {

        }

        private bool RunCanExecute() => true;

        private void TerminalExecute()
        {

        }

        private bool TerminalCanExecute() => true;

        private void CalculatorExecute()
        {

        }

        private bool CalculatorCanExecute() => true;

        private void SettingsExecute()
        {

        }

        private bool SettingsCanExecute() => true;

        private void HelpExecute()
        {

        }

        private bool HelpCanExecute() => true;

        private void AboutExecute()
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Owner = Window;
            aboutWindow.ShowDialog();
        }

        private bool AboutCanExecute() => true;
    }
}