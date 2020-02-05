using WpfNotepad.UI.Base;
using WpfNotepad.UI.Models;

namespace WpfNotepad.UI.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
		#region Fields

		// Document that is save, loaded and hold editor text
		private DocumentModel _document;
		private EditorViewModel _editor;
		private FileViewModel _file;
		private HelpViewModel _help;
		private string _title;

		#endregion

		#region Properties

		/// <summary>
		/// Manages user input for document and format styles
		/// </summary>
		public EditorViewModel Editor
		{
			get => _editor;
			set => NotifyPropertyChanged(ref _editor, value);
		}

		/// <summary>
		/// Manages saving and loading text files
		/// </summary>
		public FileViewModel File
		{
			get => _file;
			set => NotifyPropertyChanged(ref _file, value);
		}

		/// <summary>
		/// Manages help dialog
		/// </summary>
		public HelpViewModel Help
		{
			get => _help;
			set => NotifyPropertyChanged(ref _help, value);
		}

		/// <summary>
		/// Sets the title of the main view
		/// </summary>
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