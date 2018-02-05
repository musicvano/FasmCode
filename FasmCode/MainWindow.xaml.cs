using FasmCode.ViewModels;
using System.Windows;

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
            InputBindings.AddRange(viewModel.KeyBindings);
        }
    }
}
