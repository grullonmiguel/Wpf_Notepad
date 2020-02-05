namespace WpfNotepad.UI.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
		#region Fields

		private string _title;

		#endregion

		#region Properties

		public string Title
		{
			get => _title;
			set => NotifyPropertyChanged(ref _title, value);
		}

		#endregion

		#region Constructor

		public ShellViewModel()
		{
			Title = "WPF  - Notepad";
		}

		#endregion

	}
}
