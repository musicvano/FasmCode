﻿using FasmCode.ViewModels;
using ICSharpCode.AvalonEdit.Editing;
using System.Windows;
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
            var editor = sender as ICSharpCode.AvalonEdit.TextEditor;
            foreach (var item in editor.TextArea.LeftMargins)
                if (item is Line)
                {
                    var lineNumberMargin = item as Line;
                    lineNumberMargin.Margin = new Thickness(10, 0, 10, 0);
                    break;
                }
        }
    }
}