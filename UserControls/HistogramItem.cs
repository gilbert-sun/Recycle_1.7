using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Recycle.UserControls
{
	public class HistogramItem : Control
	{
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
			name: "Value",
			propertyType: typeof(double),
			ownerType: typeof(HistogramItem));

		public static readonly DependencyProperty PercentProperty = DependencyProperty.Register(
			name: "Percent",
			propertyType: typeof(double),
			ownerType: typeof(HistogramItem),
			typeMetadata: new PropertyMetadata(RefreshValue));

		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
			name: "Header",
			propertyType: typeof(string),
			ownerType: typeof(HistogramItem));

		public static readonly DependencyProperty ChartHeightProperty = DependencyProperty.Register(
			name: "ChartHeight",
			propertyType: typeof(double),
			ownerType: typeof(HistogramItem),
			typeMetadata: new PropertyMetadata(RefreshValue));

		public static readonly DependencyProperty BarHeightProperty = DependencyProperty.Register(
			name: "BarHeight",
			propertyType: typeof(double),
			ownerType: typeof(HistogramItem));

		private static void RefreshValue(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			(sender as HistogramItem).Refresh();
		}

		public double Value
		{
			get => (double)GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		public double Percent
		{
			get => (double)GetValue(PercentProperty);
			set => SetValue(PercentProperty, value);
		}

		public string Header
		{
			get => GetValue(HeaderProperty) as string;
			set => SetValue(HeaderProperty, value);
		}

		public double ChartHeight
		{
			get => (double)GetValue(ChartHeightProperty);
			set => SetValue(ChartHeightProperty, value);
		}

		public double BarHeight
		{
			get => (double)GetValue(BarHeightProperty);
			private set => SetValue(BarHeightProperty, value);
		}

		private void Refresh()
		{
			BarHeight = Percent * ChartHeight;
		}
	}
}
