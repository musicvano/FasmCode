using System.Windows;
using System.Windows.Controls;

namespace FasmCode
{
    public class CloseableTabItem: TabItem
    {
        public void SetHeader(UIElement header)
        {
            // Container for header controls
            var dockPanel = new DockPanel();
            dockPanel.Children.Add(header);

            // Close button to remove the tab
            var closeButton = new TabCloseButton();
            closeButton.Click +=
                (sender, e) =>
                {
                    var tabControl = Parent as ItemsControl;
                    tabControl.Items.Remove(this);
                };
            dockPanel.Children.Add(closeButton);

            // Set the header
            Header = dockPanel;
        }
    }
}