using System.Windows.Input;
using WpfNotepad.UI.Utilities;
using WpfNotepad.UI.Views;

namespace WpfNotepad.UI.ViewModels
{
    public class HelpViewModel : ViewModelBase
    {
        public ICommand HelpCommand { get; }

        public HelpViewModel()
        {
            HelpCommand = new RelayCommand(DisplayAbout);
        }

        private void DisplayAbout()
        {
            var helpDialog = new HelpDialog();
            helpDialog.ShowDialog();
        }
    }
}