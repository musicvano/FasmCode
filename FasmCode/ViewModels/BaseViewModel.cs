using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FasmCode.ViewModels
{
    /// <summary>
    /// Implements the behaviour of the dependency property
    /// </summary>
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies bounded property about changes 
        /// </summary>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}