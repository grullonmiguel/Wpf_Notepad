using WpfNotepad.UI.Utilities;
using WpfNotepad.UI.Models;
using System.Windows;

namespace WpfNotepad.UI.ViewModels
{
    public class ShellViewModel : ViewModelBase
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

		public ShellViewModel(Window window)
		{
			_window = window;

			Title = "WPF  - Notepad";
			_document = new DocumentModel();
			Help = new HelpViewModel();

			// NOTE: both Editor and File are 
			// assigned the same document instance
			Editor = new EditorViewModel(_document);
			File = new FileViewModel(_document);

			// listen for window resizing
			_window.StateChanged += (sender, e) =>
			{
				// Fire off events for all properties that are affected by a resize
				OnPropertyChanged(nameof(ResizeBorder));
				OnPropertyChanged(nameof(OuterMarginSize));
				OnPropertyChanged(nameof(OuterMarginSizeThickness));
				OnPropertyChanged(nameof(WindowRadius));
				OnPropertyChanged(nameof(WindowCornerRadius));
			};
		}

		#endregion

		#region WindowChrome

		/// <summary>
		/// The window this view model controls
		/// </summary>
		private Window _window;

		/// <summary>
		/// The margin around the window to allow for a drop shadow
		/// </summary>
		private int _outerMarginSize = 10;

		/// <summary>
		/// The radius of the edges of the window
		/// </summary>
		private int _windowRadius = 10;

		/// <summary>
		/// The size of the resize border around the window
		/// </summary>
		public int ResizeBorder { get; set; } = 6;

		/// <summary>
		/// The size of the resize border around the window, taking into account the outer margin
		/// </summary>
		public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

		/// <summary>
		/// The margin around the window to allow for a drop shadow
		/// </summary>
		public int OuterMarginSize
		{
			get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
			set => NotifyPropertyChanged(ref _outerMarginSize, value);
		}

		/// <summary>
		/// The margin around the window to allow for a drop shadow
		/// </summary>
		public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

		/// <summary>
		/// The radius of the edges of the window
		/// </summary>
		public int WindowRadius 
		{
			get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
			set => NotifyPropertyChanged(ref _windowRadius, value);
		}

		/// <summary>
		/// The radius of the edges of the window
		/// </summary>
		public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

		public int TitleHeight { get; set; } = 60;
		#endregion
	}
}