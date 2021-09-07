using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Recycle.UserControls
{
	public class TimelineArea : Control
	{
		public static readonly DependencyProperty DatePointsProperty = DependencyProperty.Register(
			name: "DatePoints",
			propertyType: typeof(IEnumerable<DatePoint>),
			ownerType: typeof(TimelineArea),
			typeMetadata: new PropertyMetadata(OnPointsPropertyChanged));

		public static readonly DependencyProperty MaxSecondProperty = DependencyProperty.Register(
			name: "MaxSecond",
			propertyType: typeof(double),
			ownerType: typeof(TimelineArea),
			typeMetadata: new PropertyMetadata(900.0, RaiseRenderChanged));

		public static readonly DependencyProperty NowProperty = DependencyProperty.Register(
			name: "Now",
			propertyType: typeof(DateTime),
			ownerType: typeof(TimelineArea),
			typeMetadata: new PropertyMetadata(RaiseRenderChanged));

		public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
			name: "MinValue",
			propertyType: typeof(double),
			ownerType: typeof(TimelineArea),
			typeMetadata: new PropertyMetadata(0.0, RaiseRenderChanged));

		public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
			name: "MaxValue",
			propertyType: typeof(double),
			ownerType: typeof(TimelineArea),
			typeMetadata: new PropertyMetadata(100.0, RaiseRenderChanged));

		private static void OnPointsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var control = d as TimelineArea;

			if (e.OldValue is INotifyCollectionChanged oldValue)
			{
				oldValue.CollectionChanged -= control.OnPointsCollectionChanged;
			}
			if (e.NewValue is INotifyCollectionChanged newValue)
			{
				newValue.CollectionChanged += control.OnPointsCollectionChanged;
			}
		}

		private static void RaiseRenderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as Control).InvalidateVisual();

		private void OnPointsCollectionChanged(object s, NotifyCollectionChangedEventArgs e) => InvalidateVisual();

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

		protected override void OnRender(DrawingContext drawingContext)
		{
			var width = ActualWidth;
			var height = ActualHeight;
			if (width == 0 || height == 0 || (DatePoints?.Count() ?? 0) == 0)
			{
				return;
			}
			// draw data
			var unitX = width / MaxSecond;
			var unitY = height / (MaxValue - MinValue);
			Point p;
			bool isTerminated = false;
			var now = Now;
			var geometry = new StreamGeometry();
			using (var context = geometry.Open())
			{
				p = MapTo(
					point: DatePoints.First(),
					now: now,
					scaleX: unitX,
					scaleY: unitY,
					height: height);
				var first = p;
				context.BeginFigure(new Point(p.X, height), false, false);
				context.LineTo(p, true, false);
				foreach (var point in DatePoints.Skip(1))
				{
					if (point.Value == 0)
					{
						if (!isTerminated)
						{
							p = new Point(p.X, height);
							context.LineTo(p, true, false);
							isTerminated = true;
						}
						continue;
					}

					p = MapTo(
						point: point,
						now: now,
						scaleX: unitX,
						scaleY: unitY,
						height: height);
					if (isTerminated)
					{
						context.BeginFigure(new Point(p.X, height), false, false);
						isTerminated = false;
					}
					context.LineTo(p, true, false);
				}
			}
			geometry.Freeze();
			var pen = new Pen(BorderBrush, BorderThickness.Left)
			{
				LineJoin = PenLineJoin.Bevel
			};
			pen.Freeze();
			drawingContext.DrawGeometry(null, pen, geometry);
		}

		private Point MapTo(DatePoint point, DateTime now, double scaleX, double scaleY, double height)
		{
			var x = (now - point.Time).TotalSeconds;
			var y = point.Value;
			if (y < MinValue)
			{
				y = MinValue;
			}
			else if (y > MaxValue)
			{
				y = MaxValue;
			}
			return new Point(x * scaleX, height - y * scaleY);
		}
	}
}
