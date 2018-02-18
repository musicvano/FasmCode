using System;
using System.Windows;
using System.Windows.Controls;

namespace FasmCode
{
    /// <summary>
    /// Interaction logic for UserControl.xaml
    /// </summary>
    public partial class TabCloseButton : UserControl
    {
        public event EventHandler Click;

        public TabCloseButton()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(sender, e);
        }
    }
}
