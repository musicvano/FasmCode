using System.Windows;

namespace FasmCode.ViewModels
{
    class OutputViewModel : BaseViewModel
    {
        // Defines the visibility of the bottom output panel
        private Visibility visibility;
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

        public OutputViewModel()
        {
            visibility = Visibility.Visible;
        }

        // Toggles visibility of the panel
        public void Toggle()
        {
            Visibility = visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }
    }
}