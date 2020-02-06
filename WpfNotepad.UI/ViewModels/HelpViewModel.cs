using System.Windows.Input;
using WpfNotepad.UI.Base;

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

        }
    }
}