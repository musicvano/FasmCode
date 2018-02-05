using FasmCode.Commands;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace FasmCode.ViewModels
{
    class MainViewModel
    {
        public ICommand NewFileCommand { get; set; }
        public ICommand OpenFileCommand { get; set; }
        public ICommand OpenFolderCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand SaveAllCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand CloseFolderCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public ICommand CompileCommand { get; set; }
        public ICommand RunCommand { get; set; }

        public InputBindingCollection HotKeys { get; set; }

        public MainViewModel()
        {
            NewFileCommand = new RelayCommand(NewFileExecute, NewFileCanExecute);
            OpenFileCommand = new RelayCommand(OpenFileExecute, OpenFileCanExecute);
            OpenFolderCommand = new RelayCommand(OpenFolder);
            SaveCommand = new RelayCommand(Save);
            SaveAsCommand = new RelayCommand(SaveAs);
            SaveAllCommand = new RelayCommand(SaveAll);
            CloseCommand = new RelayCommand(Close);
            CloseFolderCommand = new RelayCommand(CloseFolder);
            ExitCommand = new RelayCommand(Exit);
            CompileCommand = new RelayCommand(Compile);
            RunCommand = new RelayCommand(Run);

            // Load from file Config/HotKeys.toml
            string keyStr = "Ctrl+Shift+F6";
            KeyGestureConverter converter = new KeyGestureConverter();
            HotKeys = new InputBindingCollection();
            
            var hotKey = (KeyGesture)converter.ConvertFromString(keyStr);
            HotKeys.Add(new KeyBinding(OpenFileCommand, new KeyGesture(hotKey.Key, hotKey.Modifiers, keyStr)));
        }

        public void NewFileExecute()
        {
            throw new NotImplementedException();
        }

        private bool NewFileCanExecute() => true;

        private void OpenFileExecute()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private bool OpenFileCanExecute() => true;

        private void OpenFolder()
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            throw new NotImplementedException();
        }

        private void SaveAs()
        {
            throw new NotImplementedException();
        }

        private void SaveAll()
        {
            throw new NotImplementedException();
        }

        private void Close()
        {
            throw new NotImplementedException();
        }

        private void CloseFolder()
        {
            throw new NotImplementedException();
        }

        private void Exit()
        {
            throw new NotImplementedException();
        }

        private void Compile()
        {
            throw new NotImplementedException();
        }

        private void Run()
        {
            throw new NotImplementedException();
        }
    }
}