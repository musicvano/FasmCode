using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FasmCode.ViewModels
{
    class OutputViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Is true if the directory has been opened
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

        // Implements INotifyPropertyChanged behaviour
        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public OutputViewModel()
        {
            visibility = Visibility.Visible;
        }

        public void Toggle()
        {
            Visibility = visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }
    }
}