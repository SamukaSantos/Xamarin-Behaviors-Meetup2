

using Xamarin.Forms;

namespace aula8
{
    public class MaxLengthValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
            base.OnAttachedTo(bindable);
        }

        void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            entry.TextColor = entry.Text.Length > 10 ? Color.Red : Color.White;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
            base.OnDetachingFrom(bindable);
        }

    }
}
