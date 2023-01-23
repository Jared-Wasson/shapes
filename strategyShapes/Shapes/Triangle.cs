using System;
namespace strategyShapes.Shapes
{
	public class Triangle
	{
		double side1;
		double side2;
		double side3;
		ShapeTypes name;

		public Triangle( ShapeTypes name, double side1, double side2, double side3)
		{
			this.name = name;
			this.side1 = side1;
			this.side2 = side2;
			this.side3 = side3;
		}

		public double getAera()
		{
			double s = calculcateSemiPerimeter();
			double area = Math.Sqrt(
				s * (s - side1) * (s - side2) * (s - side3)
				);
			return area;

		}

		private double calculcateSemiPerimeter()
		{
			return (this.side1 + this.side2 + this.side3) / 2; 
		}

		public ParentShapes getParent()
		{
			return ParentShapes.TRIANGLES;
		}
	}
}

