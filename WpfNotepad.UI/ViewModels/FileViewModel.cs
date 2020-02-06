using Microsoft.Win32;
using System;
using System.Windows.Input;
using WpfNotepad.UI.Base;
using WpfNotepad.UI.Factories;
using WpfNotepad.UI.Models;

namespace WpfNotepad.UI.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; set; }
        public ICommand ExitCommand { get; }

        public ICommand NewCommand { get; }

        public ICommand SaveCommand { get; }

        public ICommand SaveAsCommand { get; }

        public ICommand OpenCommand { get; }

        public FileViewModel(DocumentModel document)
        {
            Document = document;
            ExitCommand = new RelayCommand(CloseApp);
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
        }

        private void CloseApp()
        {
            Environment.Exit(0);
        }

        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
        }

        public void SaveFile()
        {
            if ((Document.FileName == string.Empty) || (Document.FileName == null))
                SaveFileAs();
            else
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
    }
}