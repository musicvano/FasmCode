using FasmCode.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace FasmCode.ViewModels
{
    /// <summary>
    /// Represents a folder structure
    /// </summary>
    class FolderViewModel : BaseViewModel
    {
        /// <summary>
        /// Creates an new FolderViewModel instance
        /// </summary>
        public FolderViewModel()
        {
            visibility = Visibility.Collapsed;
            Items = new ObservableCollection<FileSystemItem>();
        }

        /// <summary>
        /// Opens a folder and loads an entire tree with subfolders and files
        /// </summary>
        public void Open(string path)
        {
            Items.Clear();
            Items.Add(new FolderItem(path));
            Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Close a folder tree
        /// </summary>
        public void Close()
        {
            Items.Clear();
            Visibility = Visibility.Collapsed;
        }

        private Visibility visibility;

        /// <summary>
        /// Defines the visibility of the left folder panel
        /// </summary>
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                if (value == visibility) return;
                visibility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Represents a collection of an opened folder
        /// </summary>
        public ObservableCollection<FileSystemItem> Items { get; set; }

        /// <summary>
        /// Toogles visibility of the panel
        /// </summary>
        public void Toggle()
        {
            Visibility = visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        /// <summary>
        /// Returns true if a folder isn't loaded
        /// </summary>
        public bool IsEmpty
        {
            get { return Items.Count == 0; }
        }

    }
}