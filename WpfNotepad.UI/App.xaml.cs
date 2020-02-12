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

            var view = new ShellView ();
            var viewModel = new ShellViewModel(view);
            view.DataContext = viewModel;
            view.ShowDialog();
        }
    }
}