

using Xamarin.Forms;
namespace aula8
{
    public class ColorConverter<T> : IValueConverter
    {

        public T ValidObject { get; set; }
        public T InvalidObject { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? this.ValidObject : this.InvalidObject;
        }


        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((T)value).Equals(this.ValidObject);
        }
    }
}
