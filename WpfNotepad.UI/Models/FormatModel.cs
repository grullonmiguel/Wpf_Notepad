using System.Windows;
using System.Windows.Media;

namespace WpfNotepad.UI.Models
{
    public class FormatModel
    {
        private TextWrapping wrap;

        public FontStyle Style { get; set; }

        public FontWeight Weight { get; set; }

        public FontFamily Family { get; set; }

        public TextWrapping Wrap
        {
            get => wrap;
            set
            {
                wrap = value;
                IsWrapped = value == TextWrapping.Wrap ? true : false;
            }
        }

        public bool IsWrapped { get; set; }

        public double Size { get; set; }
    }
}