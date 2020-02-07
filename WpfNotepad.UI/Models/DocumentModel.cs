using WpfNotepad.UI.Utilities;

namespace WpfNotepad.UI.Models
{
    public class DocumentModel : ViewModelBase
    {
        private string fileName;
        private string filePath;
        private string text;

        public string FileName 
        { 
            get => fileName;
            set => NotifyPropertyChanged(ref fileName, value);
        }

        public string FilePath 
        { 
            get => filePath;
            set => NotifyPropertyChanged(ref filePath, value);
        }

        public string Text 
        { 
            get => text;
            set => NotifyPropertyChanged(ref text, value); 
        }

        /// <summary>
        /// Returns true when FileName or FilePath do not have values
        /// </summary>
        public bool IsEmpty
        {
            get => string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath);
        }
    }
}