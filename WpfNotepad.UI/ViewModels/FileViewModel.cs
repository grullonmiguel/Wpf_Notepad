using Microsoft.Win32;
using System.Windows.Input;
using WpfNotepad.UI.Base;
using WpfNotepad.UI.Factories;
using WpfNotepad.UI.Models;

namespace WpfNotepad.UI.ViewModels
{
    public class FileViewModel : BaseViewModel
    {
        #region Properties

        private DocumentModel _document;
        public DocumentModel Document
        {
            get => _document;
            private set => NotifyPropertyChanged(ref _document, value);
        }

        #endregion

        #region ICommands

        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }

        #endregion

        #region Constructor

        public FileViewModel(DocumentModel document)
        {
            Document = document;

            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
        }

        #endregion

        #region Methods

        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
        }

        public void SaveFile()
        {
            FileDialogFactory.WriteAllText(Document.FilePath, Document.Text);
        }

        private void SaveFileAs()
        {
            var saveFileDialog = FileDialogFactory.CreateSaveFileDialog();
            
            if (saveFileDialog.ShowDialog() == true)
            {
                UpdateFileInfo(saveFileDialog);
                FileDialogFactory.WriteAllText(saveFileDialog.FileName, Document.Text);
            }
        }

        private void OpenFile()
        {
            var openFileDialog = FileDialogFactory.CreateOpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                UpdateFileInfo(openFileDialog);
                Document.Text = FileDialogFactory.ReadAllText(openFileDialog.FileName);
            }
        }

        private void UpdateFileInfo<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }

        #endregion
    }
}