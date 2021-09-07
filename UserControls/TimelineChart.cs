using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Recycle.UserControls
{
	public class TimelineChart : Control
	{
		public static readonly DependencyProperty DatePointsProperty = DependencyProperty.Register(
			name: "DatePoints",
			propertyType: typeof(IEnumerable<DatePoint>),
			ownerType: typeof(TimelineChart));

		public static readonly DependencyProperty MaxSecondProperty = DependencyProperty.Register(
			name: "MaxSecond",
			propertyType: typeof(double),
			ownerType: typeof(TimelineChart),
			typeMetadata: new PropertyMetadata(930.0, RaiseColumnsChanged));

		public static readonly DependencyProperty NowProperty = DependencyProperty.Register(
			name: "Now",
			propertyType: typeof(DateTime),
			ownerType: typeof(TimelineChart));

		public static readonly DependencyProperty ChartHeightProperty = DependencyProperty.Register(
			name: "ChartHeight",
			propertyType: typeof(double),
			ownerType: typeof(TimelineChart),
			typeMetadata: new PropertyMetadata(300.0, RaiseRowsChanged));

		public static readonly DependencyProperty ChartWidthProperty = DependencyProperty.Register(
			name: "ChartWidth",
			propertyType: typeof(double),
			ownerType: typeof(TimelineChart),
			typeMetadata: new PropertyMetadata(400.0, RaiseColumnsChanged));

		public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
			name: "MinValue",
			propertyType: typeof(double),
			ownerType: typeof(TimelineChart),
			typeMetadata: new PropertyMetadata(0.0, RaiseRowsChanged));

		public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
			name: "MaxValue",
			propertyType: typeof(double),
			ownerType: typeof(TimelineChart),
			typeMetadata: new PropertyMetadata(45.0, RaiseRowsChanged));

		public static readonly DependencyProperty TimeUnitProperty = DependencyProperty.Register(
			name: "TimeUnit",
			propertyType: typeof(string),
			ownerType: typeof(TimelineChart),
			typeMetadata: new PropertyMetadata(Recycle.TimeUnit.MINUTE, TimeUnitChanged));

		public static readonly DependencyProperty UnitValueProperty = DependencyProperty.Register(
			name: "UnitValue",
			propertyType: typeof(double),
			ownerType: typeof(TimelineChart),
			typeMetadata: new PropertyMetadata(10.0, RaiseRowsChanged));

		public static readonly DependencyProperty UnitSecondProperty = DependencyProperty.Register(
			name: "UnitSecond",
			propertyType: typeof(double),
			ownerType: typeof(TimelineChart),
			typeMetadata: new PropertyMetadata(300.0, RaiseColumnsChanged));

		public static readonly DependencyProperty LabelXProperty = DependencyProperty.Register(
			name: "LabelX",
			propertyType: typeof(string),
			ownerType: typeof(TimelineChart));

		public static readonly DependencyProperty LabelYProperty = DependencyProperty.Register(
			name: "LabelY",
			propertyType: typeof(string),
			ownerType: typeof(TimelineChart));

		protected static void RaiseRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as TimelineChart).DrawRowsLabel();
		}

		protected static void RaiseColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as TimelineChart).DrawColumnsLabel();
		}

		protected static void TimeUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var item = d as TimelineChart;
			item.format = Recycle.TimeUnit.GetFormatFunction(e.NewValue as string);
		}

		public IEnumerable<DatePoint> DatePoints
		{
			get => GetValue(DatePointsProperty) as IEnumerable<DatePoint>;
			set => SetValue(DatePointsProperty, value);
		}

		public double MaxSecond
		{
			get => (double)GetValue(MaxSecondProperty);
			set => SetValue(MaxSecondProperty, value);
		}

		public DateTime Now
		{
			get => (DateTime)GetValue(NowProperty);
			set => SetValue(NowProperty, value);
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

		public string TimeUnit
		{
			get => GetValue(TimeUnitProperty) as string;
			set => SetValue(TimeUnitProperty, value);
		}

		public double UnitValue
		{
			get => (double)GetValue(UnitValueProperty);
			set => SetValue(UnitValueProperty, value);
		}

		public double UnitSecond
		{
			get => (double)GetValue(UnitSecondProperty);
			set => SetValue(UnitSecondProperty, value);
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

		private ItemsControl columnsControl;

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			rowsControl = GetTemplateChild("PART_Rows") as ItemsControl;
			columnsControl = GetTemplateChild("PART_Columns") as ItemsControl;
			DrawRowsLabel();
			DrawColumnsLabel();
		}

		private void DrawRowsLabel() => ChartHelper.DrawRowsLabel(
			rowsControl: rowsControl,
			min: MinValue,
			max: MaxValue,
			unit: UnitValue,
			pixel: ChartHeight);

		private void DrawColumnsLabel() => ChartHelper.DrawColumnsLabel(
			columnsControl: columnsControl,
			min: 0,
			max: MaxSecond,
			unit: UnitSecond,
			pixel: ChartWidth,
			format: format);

		private Func<double, string> format = i => i.ToString();
	}
}
