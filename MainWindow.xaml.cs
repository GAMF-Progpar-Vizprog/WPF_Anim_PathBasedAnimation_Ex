using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace WPF_Anim_PathBasedAnimation_Ex
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}


		private void btStart_Click(object sender, RoutedEventArgs e)
		{
			
			PathGeometry pgPath = new PathGeometry();
			
			PathFigure pfPath = new PathFigure();
			
			pfPath.StartPoint = new Point(200, 200);
			
			rcSqare.SetValue(Canvas.LeftProperty, pfPath.StartPoint.X);
			rcSqare.SetValue(Canvas.TopProperty, pfPath.StartPoint.Y);
			
			
			var asSpirál = new ArchimedeanSpiral(pfPath.StartPoint.X, pfPath.StartPoint.Y,
				10, 0, 1080, 5);
			
			PolyLineSegment plsLine =
				new PolyLineSegment((System.Collections.Generic.IEnumerable<Point>)asSpirál.Points, true);
			
			pfPath.Segments.Add(plsLine);
			pgPath.Figures.Add(pfPath);
			pgPath.Freeze();
			
			Path ptLine = new Path();
			
			ptLine.Data = pgPath;
			ptLine.Stroke = Brushes.Black;
			ptLine.StrokeThickness = 2;
			cvPage.Children.Add(ptLine);
			
			DoubleAnimationUsingPath daxAnim =
					new DoubleAnimationUsingPath();
			
			daxAnim.PathGeometry = pgPath;
			daxAnim.Duration = TimeSpan.FromSeconds(10);
			daxAnim.Source = PathAnimationSource.X;
			daxAnim.AutoReverse = true;
		
			DoubleAnimationUsingPath dayAnim =
					new DoubleAnimationUsingPath();
			dayAnim.PathGeometry = pgPath;
			dayAnim.Duration = TimeSpan.FromSeconds(10);
			dayAnim.Source = PathAnimationSource.Y;
			dayAnim.AutoReverse = true;
			
			rcSqare.BeginAnimation(Canvas.TopProperty, dayAnim);
			rcSqare.BeginAnimation(Canvas.LeftProperty, daxAnim);
		}
	}
}
