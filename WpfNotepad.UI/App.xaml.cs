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

            DisplayMainView();
        }

        private void DisplayMainView()
        {
            var viewModel = new ShellViewModel();

            var view = new ShellView { DataContext = viewModel };

            view.ShowDialog();
        }
    }
}