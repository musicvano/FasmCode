using FasmCode.Models;
using System.Collections.Generic;
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
            visibility = Visibility.Visible;
            Items = new List<Item>();
            Items.Add(new FolderItem(@"d:\Folder"));
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
        /// Opened root folder
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Toogles visibility of the panel
        /// </summary>
        public void Toggle()
        {
            Visibility = visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }
    }
}