using System.Windows.Input;

namespace FasmCode.Commands
{
    public interface IRelayCommand : ICommand
    {
        KeyGesture HotKey { get; set; }
    }
}