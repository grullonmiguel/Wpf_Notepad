using System.Windows;
using WpfNotepad.UI.ViewModels;
using WpfNotepad.UI.Views;

namespace WpfNotepad.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var view = new ShellView { DataContext = new ShellViewModel() };

            view.ShowDialog();
        }
    }
}