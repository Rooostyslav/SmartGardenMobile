using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using System.Resources;

namespace SmartGardenMobile.Localization
{
	[ContentProperty("Text")]
	public class TranslateExtension : IMarkupExtension
	{
        private readonly CultureInfo ci;
        private const string ResourceId = "SmartGardenMobile.ResourceFiles.Resource";

        public string Text { get; set; }

        public TranslateExtension()
        {
            ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            /*
            string lang = GetLanguage();
            if (lang == "")
			{
                ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }
			else
			{
                ci = new CultureInfo(lang);
            }
            */
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId,
                        typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
                translation = Text;
            }
            return translation;
        }

        private string GetLanguage()
		{
            string key = "lang";
            if (App.Current.Properties.ContainsKey(key))
			{
                return App.Current.Properties[key].ToString();
			}
            else
			{
                return "";
            }
        }
    }
}
