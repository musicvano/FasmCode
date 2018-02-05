using FasmCode.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace FasmCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = (MainViewModel)DataContext;
            InputBindings.AddRange(viewModel.HotKeys);
        }
    }
}
