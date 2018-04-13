using System.Windows;

namespace FasmCode.ViewModels
{
    class FolderViewModel : BaseViewModel
    {
        // Defines the visibility of the left folder panel
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

        public FolderViewModel()
        {
            visibility = Visibility.Visible;
        }

        // Toogles visibility of the panel
        public void Toggle()
        {
            Visibility = visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }
    }
}