using Xamarin.Forms;
using SmartGardenMobile.Localization;
[assembly: Dependency(typeof(SmartGardenMobile.Droid.Localize))]

namespace SmartGardenMobile.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}