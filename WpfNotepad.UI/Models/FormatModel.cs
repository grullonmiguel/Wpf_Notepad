using System.Windows;
using System.Windows.Media;
using WpfNotepad.UI.Utilities;

namespace WpfNotepad.UI.Models
{
    public class FormatModel : ViewModelBase
    {
        private TextWrapping wrap;
        private FontStyle style;
        private FontWeight weight;
        private FontFamily family;
        private bool isWrapped;
        private double size;

        public FontStyle Style
        {
            get => style;
            set => NotifyPropertyChanged(ref style, value);
        }

        public FontWeight Weight
        {
            get => weight;
            set => NotifyPropertyChanged(ref weight, value);
        }

        public FontFamily Family
        {
            get => family;
            set => NotifyPropertyChanged(ref family, value);
        }

        public TextWrapping Wrap
        {
            get => wrap;
            set
            {
                wrap = value;
                OnPropertyChanged();
                IsWrapped = value == TextWrapping.Wrap ? true : false;
            }
        }

        public bool IsWrapped
        { 
            get => isWrapped;
            set => NotifyPropertyChanged(ref isWrapped, value);
        }

        public double Size 
        { 
            get => size;
            set => NotifyPropertyChanged(ref size, value);
        }
    }
}