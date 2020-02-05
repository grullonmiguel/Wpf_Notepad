using System.Windows.Input;
using WpfNotepad.UI.Base;
using WpfNotepad.UI.Models;

namespace WpfNotepad.UI.ViewModels
{
    public class EditorViewModel : BaseViewModel
    {

        #region Fields

        private DocumentModel _document;
        private FormatModel _format;

        #endregion

        #region Properties

        public DocumentModel Document
        {
            get => _document;
            set => NotifyPropertyChanged(ref _document, value);
        }

        public FormatModel Format
        {
            get => _format;
            set => NotifyPropertyChanged(ref _format, value);
        }

        #endregion

        #region Commands

        public ICommand FormatCommand { get; }
        public ICommand WrapCommand { get; }

        #endregion

        #region Constructor

        public EditorViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();

            FormatCommand = new RelayCommand(OpenStyleDialog);
            WrapCommand = new RelayCommand(ToggleWrap);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Opens a dialog view to handle styles
        /// </summary>
        private void OpenStyleDialog()
        {

        }

        /// <summary>
        /// Changes the wrapping style
        /// </summary>
        private void ToggleWrap()
        {
            if (Format.Wrap == System.Windows.TextWrapping.Wrap)
                Format.Wrap = System.Windows.TextWrapping.NoWrap;
            else
                Format.Wrap = System.Windows.TextWrapping.Wrap;
        }

        #endregion
    }
}
