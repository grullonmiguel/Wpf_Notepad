namespace WpfNotepad.UI.Models
{
    public class DocumentModel
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// Returns true when FileName or FilePath do not have values
        /// </summary>
        public bool IsEmpty
        {
            get => string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath);
        }
    }
}