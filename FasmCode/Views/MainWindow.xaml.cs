using FasmCode.Models;
using FasmCode.ViewModels;
using ICSharpCode.AvalonEdit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace FasmCode.Views
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
            viewModel.Window = this;
            InputBindings.AddRange(viewModel.KeyBindings);
        }

        private void TextEditor_Loaded(object sender, RoutedEventArgs e)
        {
            var editor = sender as TextEditor;
            foreach (var item in editor.TextArea.LeftMargins)
                if (item is Line)
                {
                    var lineNumberMargin = item as Line;
                    lineNumberMargin.Margin = new Thickness(10, 0, 10, 0);
                    break;
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TreeViewItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is TreeViewItem)
            {
                var item = sender as TreeViewItem;
                if (!item.IsSelected) return;
                if (item.DataContext is FileItem)
                {
                    var file = item.DataContext as FileItem;
                    var viewModel = (MainViewModel)DataContext;
                    viewModel.OpenCommand?.Execute(file.Path);
                }
            }
        }
    }
}