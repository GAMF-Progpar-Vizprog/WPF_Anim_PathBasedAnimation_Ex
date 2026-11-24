using System;
using System.Collections.Generic;
using System.Windows;

namespace WPF_Anim_PathBasedAnimation_Ex
{
	
	class ArchimedeanSpiral
	{	private double x0;
		private double y0;
		private double k;
		private double StartAngle;
		private double EndAngle;
		private double Step;
		private List<Point> lpPoints;
		public ArchimedeanSpiral(double X0, double Y0, double K, double StA,
			double EA, double L)
		{	x0 = X0;
			y0 = Y0;
			k = K;
			StartAngle = StA * Math.PI / 180;
			EndAngle = EA * Math.PI / 180;
			Step = L * Math.PI / 180;
		}
		public List<Point> Points
		{	get
			{	lpPoints = new List<Point>();
				for (double fi = StartAngle; fi <= EndAngle; fi += Step)
				{	double r = k * fi;
					lpPoints.Add(new Point(x0 + r * Math.Cos(fi), y0 - r * Math.Sin(fi)));
				}
				return lpPoints;
			}
		}
	}
}
