using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace WpfNotepad.UI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Summary:
        //     Occurs when a property value changes.
        public event PropertyChangedEventHandler PropertyChanged;

        // Summary:
        //     Notifies subscribers of the property change.
        //
        // Parameters:
        //   oldValue:
        //
        //   newValue:
        //
        //   propertyName:
        //
        // Type parameters:
        //   T:
        protected virtual bool NotifyPropertyChanged<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(oldValue, newValue))
                return false;

            oldValue = newValue;

            OnPropertyChanged(propertyName);
            return true;
        }

        // Summary:
        //     Notifies subscribers of the property change.
        //
        // Parameters:
        //   oldValue:
        //
        //   newValue:
        //
        //   propertyName:
        //
        // Type parameters:
        //   T:
        protected virtual bool NotifyPropertyChanged<T>(ref T oldValue, T newValue, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (Equals(oldValue, newValue))
                return false;

            oldValue = newValue;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
            return true;
        }

        // Summary:
        //     Notifies subscribers of the property change.
        //
        // Parameters:
        //   oldValue:
        //
        //   newValue:
        //
        //   propertyName:
        //
        // Type parameters:
        //   T:
        protected virtual bool NotifyPropertyChanged<T>(ref T oldValue, T newValue, Action<T> onChanging, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (Equals(oldValue, newValue))
                return false;

            if (oldValue != null)
                onChanging(oldValue);

            oldValue = newValue;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
            return true;
        }

        // Summary:
        //     Notifies subscribers of the property change.
        //
        // Parameters:
        //   propertyName:
        //     Name of the property.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Summary:
        //     Notifies subscribers of the property change.
        //
        // Parameters:
        //   property:
        //     The property expression.
        //
        // Type parameters:
        //   TProperty:
        //     The type of the property.
        protected void OnPropertyChanged<T>(Expression<Func<T>> property)
        {
            OnPropertyChanged(ExtractPropertyName(property));
        }

        #region Helper Methods

        private string ExtractPropertyName<T>(Expression<Func<T>> property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            if (!(property.Body is MemberExpression body))
                throw new ArgumentException("Unable to access Expression", nameof(property));

            PropertyInfo member = body.Member as PropertyInfo;

            if (member == null)
                throw new ArgumentException("Expression is not a Property", nameof(property));

            if (member.GetMethod.IsStatic)
                throw new ArgumentException("Static Member not allowed for Expression", nameof(property));

            return body.Member.Name;
        }

        #endregion
    }
}