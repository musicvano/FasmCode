using FasmCode.Commands;
using FasmCode.Settings;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

namespace FasmCode.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
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
        public ObservableCollection<SourceViewModel> Sources { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private int selectedSourceIndex;

        public int SelectedSourceIndex
        {
            get { return selectedSourceIndex; }
            set
            {
                if (value == selectedSourceIndex) return;
                selectedSourceIndex = value;
                OnPropertyChanged();
            }
        }

        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            Settings = new SettingsManager();
            CreateCommands();
            CreateKeyBindings();
            Sources = new ObservableCollection<SourceViewModel>();
        }

        private void CreateCommands()
        {
            WindowLoaded = new RelayCommand(WindowLoadedExecute, param => true);
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

        private void WindowLoadedExecute(object param)
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
                //Window.textEditor.SyntaxHighlighting = HighlightingLoader.Load(syntax, HighlightingManager.Instance);
            }
        }

        private void NewExecute(object param)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "New File",
                DefaultExt = "asm",
                OverwritePrompt = true,
                FileName = "file.asm",
                Filter = "Assembly File (*.asm)|*.asm|Include File (*.inc)|*.inc"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var source = new SourceViewModel();
                source.Document.FileName = dialog.FileName;
                Sources.Add(source);
                SelectedSourceIndex = Sources.Count - 1;
                File.Create(dialog.FileName).Close();
            }
        }

        private bool NewCanExecute(object param) => true;

        private void OpenExecute(object param)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Assembly Files (*.asm)|*.asm|Include Files (*.inc)|*.inc|All Files(*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var reader = new StreamReader(dialog.FileName))
                {
                    var source = new SourceViewModel();
                    source.Document.FileName = dialog.FileName;
                    source.Document.Text = reader.ReadToEnd();
                    Sources.Add(source);
                    SelectedSourceIndex = Sources.Count - 1;
                }
            }
        }

        private bool OpenCanExecute(object param) => true;

        private void OpenFolderExecute(object param)
        {

        }

        private bool OpenFolderCanExecute(object param) => true;

        private void SaveExecute(object param)
        {

        }

        private bool SaveCanExecute(object param)
        {
            return Sources.Count > 0;
        }

        private void SaveAsExecute(object param)
        {
            var source = Sources[SelectedSourceIndex];
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Save File As",
                DefaultExt = "asm",
                OverwritePrompt = true,
                FileName = source.ShortFileName,
                Filter = "Assembly File (*.asm)|*.asm|Include File (*.inc)|*.inc"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(dialog.FileName))
                {
                    writer.Write(source.Document.Text);
                }
            }
        }

        private bool SaveAsCanExecute(object param)
        {
            return Sources.Count > 0;
        }

        private void SaveAllExecute(object param)
        {
            foreach (var source in Sources)
            {
                using (var writer = new StreamWriter(source.Document.FileName))
                {
                    writer.Write(source.Document.Text);
                }
            }
        }

        private bool SaveAllCanExecute(object param)
        {
            return Sources.Count > 0;
        }

        private void CloseExecute(object parameter)
        {
            if (parameter is SourceViewModel)
            {
                Sources.Remove(parameter as SourceViewModel);
            }
            else
            {
                Sources.RemoveAt(SelectedSourceIndex);
            }
        }

        private bool CloseCanExecute(object param) => true;

        private void CloseFolderExecute(object param)
        {

        }

        private bool CloseFolderCanExecute(object param) => true;

        private void ExitExecute(object param)
        {

        }

        private bool ExitCanExecute(object param) => true;

        private void UndoExecute(object param)
        {

        }

        private bool UndoCanExecute(object param) => true;

        private void RedoExecute(object param)
        {

        }

        private bool RedoCanExecute(object param) => true;

        private void CutExecute(object param)
        {

        }

        private bool CutCanExecute(object param) => true;

        private void CopyExecute(object param)
        {

        }

        private bool CopyCanExecute(object param) => true;

        private void PasteExecute(object param)
        {

        }

        private bool PasteCanExecute(object param) => true;

        private void DeleteExecute(object param)
        {

        }

        private bool DeleteCanExecute(object param) => true;

        private void SelectAllExecute(object param)
        {

        }

        private bool SelectAllCanExecute(object param) => true;

        private void FindExecute(object param)
        {

        }

        private bool FindCanExecute(object param) => true;

        private void ReplaceExecute(object param)
        {

        }

        private bool ReplaceCanExecute(object param) => true;

        private void CompileExecute(object param)
        {

        }

        private bool CompileCanExecute(object param) => true;

        private void RunExecute(object param)
        {

        }

        private bool RunCanExecute(object param) => true;

        private void TerminalExecute(object param)
        {

        }

        private bool TerminalCanExecute(object param) => true;

        private void CalculatorExecute(object param)
        {

        }

        private bool CalculatorCanExecute(object param) => true;

        private void SettingsExecute(object param)
        {

        }

        private bool SettingsCanExecute(object param) => true;

        private void HelpExecute(object param)
        {

        }

        private bool HelpCanExecute(object param) => true;

        private void AboutExecute(object param)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Owner = param as Window;
            aboutWindow.ShowDialog();
        }

        private bool AboutCanExecute(object param) => true;
    }
}