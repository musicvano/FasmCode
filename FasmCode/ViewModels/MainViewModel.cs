using FasmCode.Commands;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace FasmCode.ViewModels
{
    class MainViewModel
    {
        public ICommand NewCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand OpenFolderCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand SaveAllCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand CloseFolderCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public ICommand CompileCommand { get; set; }
        public ICommand RunCommand { get; set; }

        public DateTime Date { get; set; }

        public MainViewModel()
        {
            NewCommand = new RelayCommand(New);
            OpenCommand = new RelayCommand(Open);
            OpenFolderCommand = new RelayCommand(OpenFolder);
            SaveCommand = new RelayCommand(Save);
            SaveAsCommand = new RelayCommand(SaveAs);
            SaveAllCommand = new RelayCommand(SaveAll);
            CloseCommand = new RelayCommand(Close);
            CloseFolderCommand = new RelayCommand(CloseFolder);
            ExitCommand = new RelayCommand(Exit);
            CompileCommand = new RelayCommand(Compile);
            RunCommand = new RelayCommand(Run);
            Date = DateTime.Now;
        }

        public void New()
        {
            throw new NotImplementedException();
        }

        private void Open()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

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