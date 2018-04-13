using System.Windows;

namespace FasmCode.ViewModels
{
    /// <summary>
    /// Represents an output message panel
    /// </summary>
    class OutputViewModel : BaseViewModel
    {
        /// <summary>
        /// Creates a new OutputViewModel instance
        /// </summary>
        public OutputViewModel()
        {
            visibility = Visibility.Visible;
            text = "Compilation...";
        }

        private Visibility visibility;

        /// <summary>
        /// Defines the visibility of the bottom output panel
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

        private string text;

        /// <summary>
        /// Contains the text for output
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                if (value == text) return;
                text = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Toggles visibility of the panel
        /// </summary>
        public void Toggle()
        {
            Visibility = visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }
    }
}