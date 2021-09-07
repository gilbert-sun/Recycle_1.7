using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Recycle.UserControls
{
	public class Histogram : ItemsControl
	{
		public static readonly DependencyProperty ChartHeightProperty = DependencyProperty.Register(
			name: "ChartHeight",
			propertyType: typeof(double),
			ownerType: typeof(Histogram),
			typeMetadata: new PropertyMetadata(300.0, RaiseRowsChanged));

		public static readonly DependencyProperty ChartWidthProperty = DependencyProperty.Register(
			name: "ChartWidth",
			propertyType: typeof(double),
			ownerType: typeof(Histogram),
			typeMetadata: new PropertyMetadata(400.0));

		public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
			name: "MinValue",
			propertyType: typeof(double),
			ownerType: typeof(Histogram),
			typeMetadata: new PropertyMetadata(0.0, RaiseRowsChanged));

		public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
			name: "MaxValue",
			propertyType: typeof(double),
			ownerType: typeof(Histogram),
			typeMetadata: new PropertyMetadata(100.0, RaiseRowsChanged));

		public static readonly DependencyProperty UnitValueProperty = DependencyProperty.Register(
			name: "UnitValue",
			propertyType: typeof(double),
			ownerType: typeof(Histogram),
			typeMetadata: new PropertyMetadata(25.0, RaiseRowsChanged));

		public static readonly DependencyProperty LabelXProperty = DependencyProperty.Register(
			name: "LabelX",
			propertyType: typeof(string),
			ownerType: typeof(Histogram));

		public static readonly DependencyProperty LabelYProperty = DependencyProperty.Register(
			name: "LabelY",
			propertyType: typeof(string),
			ownerType: typeof(Histogram));

		protected static void RaiseRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as Histogram).DrawRowsLabel();
		}

		public double ChartHeight
		{
			get => (double)GetValue(ChartHeightProperty);
			set => SetValue(ChartHeightProperty, value);
		}

		public double ChartWidth
		{
			get => (double)GetValue(ChartWidthProperty);
			set => SetValue(ChartWidthProperty, value);
		}

		public double MinValue
		{
			get => (double)GetValue(MinValueProperty);
			set => SetValue(MinValueProperty, value);
		}

		public double MaxValue
		{
			get => (double)GetValue(MaxValueProperty);
			set => SetValue(MaxValueProperty, value);
		}

		public double UnitValue
		{
			get => (double)GetValue(UnitValueProperty);
			set => SetValue(UnitValueProperty, value);
		}

		public string LabelX
		{
			get => GetValue(LabelXProperty) as string;
			set => SetValue(LabelXProperty, value);
		}

		public string LabelY
		{
			get => GetValue(LabelYProperty) as string;
			set => SetValue(LabelYProperty, value);
		}

		private ItemsControl rowsControl;

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			rowsControl = GetTemplateChild("PART_Rows") as ItemsControl;
			DrawRowsLabel();
		}

		private void DrawRowsLabel() => ChartHelper.DrawRowsLabel(
			rowsControl: rowsControl,
			min: MinValue,
			max: MaxValue,
			unit: UnitValue,
			pixel: ChartHeight);
	}
}
