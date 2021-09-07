using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Recycle.UserControls
{
	public class ChartGrid : ChartBase
	{
		public static readonly DependencyProperty UnitXProperty = DependencyProperty.Register(
			name: "UnitX",
			propertyType: typeof(double),
			ownerType: typeof(ChartGrid),
			typeMetadata: new PropertyMetadata(15.0, RaiseRenderChanged));

		public static readonly DependencyProperty UnitYProperty = DependencyProperty.Register(
			name: "UnitY",
			propertyType: typeof(double),
			ownerType: typeof(ChartGrid),
			typeMetadata: new PropertyMetadata(15.0, RaiseRenderChanged));

		public double UnitX
		{
			get => (double)GetValue(UnitXProperty);
			set => SetValue(UnitXProperty, value);
		}

		public double UnitY
		{
			get => (double)GetValue(UnitYProperty);
			set => SetValue(UnitYProperty, value);
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			var width = ActualWidth;
			var height = ActualHeight;
			if (width == 0 || height == 0)
			{
				return;
			}
			var pen = new Pen(BorderBrush, BorderThickness.Left);
			pen.Freeze();
			if (UnitX > 0)
			{
				var unitX = UnitX * width / (MaxX - MinX);
				for (Point point = new Point(0, height); point.X <= width; point.Offset(unitX, 0))
				{
					drawingContext.DrawLine(pen, point, new Point(point.X, 0));
				}
			}
			if (UnitY > 0)
			{
				var unitY = UnitY * height / (MaxY - MinY);
				for (Point point = new Point(width, height); point.Y >= 0; point.Offset(0, -unitY))
				{
					drawingContext.DrawLine(pen, point, new Point(0, point.Y));
				}
			}
		}
	}
}
