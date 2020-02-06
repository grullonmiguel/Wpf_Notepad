using System.Windows.Input;
using WpfNotepad.UI.Base;
using WpfNotepad.UI.Views;

namespace WpfNotepad.UI.ViewModels
{
    public class HelpViewModel : BaseViewModel
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