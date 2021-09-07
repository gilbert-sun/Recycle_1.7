﻿using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Recycle.Views
{
	/// <summary>
	/// LogPage.xaml 的互動邏輯
	/// </summary>
	public partial class LogPage : UserControl
	{
		public LogPage()
		{
			InitializeComponent();
		}

		public void LogInformation(string message) => LogMessage(message, App.Current.Resources["brushTitle"] as Brush);

		public void LogWarning(string message) => LogMessage(message, App.Current.Resources["brushNotiRed"] as Brush);

		public void LogCritical(string message) => LogMessage(message, App.Current.Resources["brushCritical"] as Brush);

		public void LogMessage(string message, Brush brush)
		{
			var run = new Run(message)
			{
				Foreground = brush
			};
			if (!(paragraph.Inlines.LastInline is LineBreak))
			{
				paragraph.Inlines.Add(new LineBreak());
			}
			paragraph.Inlines.Add(run);
		}

		public void Clear() => paragraph.Inlines.Clear();

		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			LogInformation("按下 [總覽]");
		}

		private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
		{
			LogInformation("按下 [機械手臂/手臂機構]");
		}

		private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
		{
			LogInformation("按下 [視覺系統]");
		}

		private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
		{
			LogInformation("按下 [輸送帶]");
		}

		private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
		{
			LogInformation("按下 [控制器]");
		}
	}
}