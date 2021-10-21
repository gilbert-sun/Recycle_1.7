using Recycle.UserControls;
using Recycle.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Recycle
{
	/// <summary>
	/// App.xaml 的互動邏輯
	/// </summary>
	public partial class App : Application
	{
		public const string LANGUAGE_ZH_TW = "zh-TW";

		public const string LANGUAGE_EN_US = "en-US";		

		public static bool ChangeCulture(string langName)
		{
			var supportLanguages = new[]
			{
				LANGUAGE_ZH_TW,
				LANGUAGE_EN_US
			};
			if (!supportLanguages.Contains(langName))
			{
				throw new Exception("Not support language.");
			}
			var uri = new Uri($"/Recycle;component/Languages/{langName}.xaml", UriKind.Relative);
			var dictionary = LoadComponent(uri) as ResourceDictionary;
			Current.Resources.MergedDictionaries[0] = dictionary;
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(langName);
			CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(langName);
			return true;
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			if (Recycle.Properties.Settings.Default.Osk)
			{
				Current.Resources["boolUseOsk"] = true;
			}
			var viewModel = Current.Resources["mainViewModel"] as MainViewModel;			
			viewModel.ChangeLanguage(LANGUAGE_ZH_TW);
		}
	}
}

