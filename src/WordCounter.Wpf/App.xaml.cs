using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace WordCounter.Wpf
{
    public partial class App : Application
    {
        /// <summary>
        /// Ensures <see cref="CultureInfo.CurrentUICulture"/> to represent user's current OS locale setting.
        /// </summary>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;
            var language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
            var metadata = new FrameworkPropertyMetadata(language);
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), metadata);
        }
    }
}
