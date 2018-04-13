using FasmCode.Commands;
using FasmCode.Settings;
using FasmCode.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace FasmCode.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // All commands of the application
        public ICommand WindowLoaded { get; set; }
        public ICommand WindowClosed { get; set; }
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

        // Collection of all key bindings
        public InputBindingCollection KeyBindings { get; set; }

        // Reference to the main window
        public System.Windows.Window Window { get; set; }

        // Application settings (hot keys, themes, general configurations)
        public SettingsManager Settings { get; set; }

        public FolderViewModel Folder { get; set; }
        public OutputViewModel Output { get; set; }

        // Collection of view models for all sources
        public ObservableCollection<SourceViewModel> Sources { get; set; }

        // Index of active source view model
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

        // Returns the active source view model
        public SourceViewModel SelectedSource
        {
            get { return Sources[SelectedSourceIndex]; }
        }

        // Implements INotifyPropertyChanged behaviour
        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            Settings = new SettingsManager();
            CreateCommands();
            CreateKeyBindings();
            Folder = new FolderViewModel();
            Sources = new ObservableCollection<SourceViewModel>();
        }

        // Initializes all commands of the application
        private void CreateCommands()
        {
            WindowLoaded = new RelayCommand(WindowLoadedExecute, param => true);
            WindowClosed = new RelayCommand(WindowClosedExecute, param => true);
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

        // Initializes all hot key of the application
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

        }

        private void WindowClosedExecute(object param)
        {
            Settings.Save();
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
                var source = new SourceViewModel(dialog.FileName);
                Sources.Add(source);
                SelectedSourceIndex = Sources.Count - 1;
                //File.Create(dialog.FileName).Close();
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
                for(int i = 0; i < Sources.Count; i++)
                    if (string.Equals(Sources[i].Document.FileName, dialog.FileName, StringComparison.OrdinalIgnoreCase))
                    {
                        SelectedSourceIndex = i;
                        return;
                    }
                var source = new SourceViewModel(dialog.FileName);
                Sources.Add(source);
                SelectedSourceIndex = Sources.Count - 1;
            }
        }

        private bool OpenCanExecute(object param) => true;

        private void OpenFolderExecute(object param)
        {

        }

        private bool OpenFolderCanExecute(object param) => true;

        private void SaveExecute(object param)
        {
            SelectedSource.Save();
        }

        private bool SaveCanExecute(object param)
        {
            return Sources.Count > 0;
        }

        private void SaveAsExecute(object param)
        {
            var source = SelectedSource;
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
                source.SaveAs(dialog.FileName);
            }
        }

        private bool SaveAsCanExecute(object param)
        {
            return Sources.Count > 0;
        }

        private void SaveAllExecute(object param)
        {
            foreach (var source in Sources)
                if (source.IsModified)
                    source.Save();
        }

        private bool SaveAllCanExecute(object param)
        {
            return Sources.Count > 0;
        }

        private void CloseExecute(object param)
        {
            var source = param is SourceViewModel ?
                param as SourceViewModel :
                SelectedSource;
            if (source.IsModified)
            {
                var result = System.Windows.MessageBox.Show(Window,
                    $"Save changes to the file?\n{source.Document.FileName}",
                    "Fasm Code",
                    System.Windows.MessageBoxButton.YesNoCancel,
                    System.Windows.MessageBoxImage.Question);
                if (result == System.Windows.MessageBoxResult.OK)
                    source.Save();
                if (result == System.Windows.MessageBoxResult.Cancel)
                    return;
            }
            Sources.Remove(source);
        }

        private bool CloseCanExecute(object param)
        {
            return Sources.Count > 0;
        }

        private void CloseFolderExecute(object param)
        {

        }

        private bool CloseFolderCanExecute(object param) => true;

        private void ExitExecute(object param)
        {
            System.Windows.Application.Current.Shutdown();
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

        private bool CompileCanExecute(object param)
        {
            return Sources.Count > 0;
        }

        private void RunExecute(object param)
        {

        }

        private bool RunCanExecute(object param)
        {
            return Sources.Count > 0;
        }

        private void TerminalExecute(object param)
        {
            Process.Start("cmd");
        }

        private bool TerminalCanExecute(object param) => true;

        private void CalculatorExecute(object param)
        {
            Process.Start("calc");
        }

        private bool CalculatorCanExecute(object param) => true;

        private void SettingsExecute(object param)
        {
            var window = new SettingsWindow();
            window.Owner = Window;
            window.ShowDialog();
        }

        private bool SettingsCanExecute(object param) => true;

        private void HelpExecute(object param)
        {
            Process.Start("https://github.com/musicvano/fasmcode");
        }

        private bool HelpCanExecute(object param) => true;

        private void AboutExecute(object param)
        {            
            var window = new AboutWindow();
            window.Owner = Window;
            window.ShowDialog();
        }

        private bool AboutCanExecute(object param) => true;
    }
}