using System.Windows;

namespace FasmCode
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string message = "An application error occurred:\n" + e.Exception.Message;
            if (e.Exception.InnerException != null)
                message += "\n" + e.Exception.InnerException.Message;
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}