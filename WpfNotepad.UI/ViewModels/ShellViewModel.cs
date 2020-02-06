using WpfNotepad.UI.Base;
using WpfNotepad.UI.Models;

namespace WpfNotepad.UI.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
		#region Properties

		// Document that is save, loaded and hold editor text
		private DocumentModel _document;

		/// Manages user input for document and format styles
		public EditorViewModel Editor { get; set; }

		/// Manages saving and loading text files
		public FileViewModel File { get; set; }

		/// Manage help dialog
		public HelpViewModel Help { get; set; }

		/// <summary>
		/// Sets the title of the main view
		/// </summary>
		private string _title;
		public string Title
		{
			get => _title;
			private set => NotifyPropertyChanged(ref _title, value);
		}

		#endregion

		#region Constructor

		public ShellViewModel()
		{
			Title = "WPF  - Notepad";
			_document = new DocumentModel();
			Help = new HelpViewModel();

			// NOTE: both Editor and File are assigned the same document instance
			Editor = new EditorViewModel(_document);
			File = new FileViewModel(_document);
		}

		#endregion

	}
}