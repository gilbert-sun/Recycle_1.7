using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Recycle.UserControls
{
	public abstract class ChartBase : Control
	{
		public static readonly DependencyProperty MinXProperty = DependencyProperty.Register(
			name: "MinX",
			propertyType: typeof(double),
			ownerType: typeof(ChartBase),
			typeMetadata: new PropertyMetadata(0.0, RaiseRenderChanged));

		public static readonly DependencyProperty MinYProperty = DependencyProperty.Register(
			name: "MinY",
			propertyType: typeof(double),
			ownerType: typeof(ChartBase),
			typeMetadata: new PropertyMetadata(0.0, RaiseRenderChanged));

		public static readonly DependencyProperty MaxXProperty = DependencyProperty.Register(
			name: "MaxX",
			propertyType: typeof(double),
			ownerType: typeof(ChartBase),
			typeMetadata: new PropertyMetadata(100.0, RaiseRenderChanged));

		public static readonly DependencyProperty MaxYProperty = DependencyProperty.Register(
			name: "MaxY",
			propertyType: typeof(double),
			ownerType: typeof(ChartBase),
			typeMetadata: new PropertyMetadata(100.0, RaiseRenderChanged));

		protected static void RaiseRenderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as Control)?.InvalidateVisual();

		public double MinX
		{
			get => (double)GetValue(MinXProperty);
			set => SetValue(MinXProperty, value);
		}

		public double MinY
		{
			get => (double)GetValue(MinYProperty);
			set => SetValue(MinYProperty, value);
		}

		public double MaxX
		{
			get => (double)GetValue(MaxXProperty);
			set => SetValue(MaxXProperty, value);
		}

		public double MaxY
		{
			get => (double)GetValue(MaxYProperty);
			set => SetValue(MaxYProperty, value);
		}
	}
}
