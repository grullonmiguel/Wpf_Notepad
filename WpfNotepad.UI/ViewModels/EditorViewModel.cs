﻿using System.Windows.Input;
using WpfNotepad.UI.Utilities;
using WpfNotepad.UI.Models;
using WpfNotepad.UI.Views;

namespace WpfNotepad.UI.ViewModels
{
    public class EditorViewModel
    {
        public DocumentModel Document { get; set; }

        public FormatModel Format { get; set; }

        public ICommand FormatCommand { get; }

        public ICommand WrapCommand { get; }

        public EditorViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();

            FormatCommand = new RelayCommand(OpenStyleDialog);
            WrapCommand = new RelayCommand(ToggleWrap);
        }

        /// <summary>
        /// Opens a dialog view to handle styles
        /// </summary>
        private void OpenStyleDialog()
        {
            var fontDialog = new FontDialog();
            fontDialog.DataContext = Format;
            fontDialog.ShowDialog();
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
    }
}