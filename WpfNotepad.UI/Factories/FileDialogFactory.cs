using Microsoft.Win32;
using System.IO;

namespace WpfNotepad.UI.Factories
{
    public static class FileDialogFactory
    {

        public static SaveFileDialog CreateSaveFileDialog()
        {
            return new SaveFileDialog
            {
                Filter = "Text File (*.txt)|*.txt"
            };
        }

        public static OpenFileDialog CreateOpenFileDialog()
        {
            return new OpenFileDialog();
        }

        public static string ReadAllText(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public static void WriteAllText(string fileName, string fileText)
        {
            File.WriteAllText(fileName, fileText);
        }
    }
}
