

using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace aula8
{
    public class EmailValidationBehavior : Behavior<Entry>
    {
        const string emailRegularExpression = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailValidationBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get 
            {
                return (bool)base.GetValue(IsValidProperty);
            }

            private set 
            {
                base.SetValue(IsValidPropertyKey, value);
            }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegularExpression, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200)));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;

        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }
    }
}
