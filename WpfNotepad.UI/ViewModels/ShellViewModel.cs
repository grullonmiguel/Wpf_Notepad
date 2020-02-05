namespace WpfNotepad.UI.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
		private string _title;

		public string Title
		{
			get => _title;
			set { _title = value; OnPropertyChanged(); }
		}

		public ShellViewModel()
		{
			Title = "WPF Notepad";
		}

	}
}
