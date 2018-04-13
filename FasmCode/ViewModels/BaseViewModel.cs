using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FasmCode.ViewModels
{
    // Implements the behaviour of the dependency property
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Notifies bounded property about changes 
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}