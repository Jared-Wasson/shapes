using System;
namespace strategyShapes.Shapes
{
	public class Ellipses
	{
		public double semiMajorAxis;
		public double semiMinorAxis;
		public ShapeTypes name;

		public Ellipses(ShapeTypes name, double semiMajorAxis, double semiMinorAxis)
		{
			this.name = name;
			this.semiMajorAxis = semiMajorAxis;
			this.semiMinorAxis = semiMinorAxis;

		}

		public double getArea()
		{
			return Math.PI * this.semiMajorAxis * this.semiMinorAxis;
		}

		public ShapeTypes getName()
		{
			return name;
		}

        public ParentShapes getParent()
		{
			return ParentShapes.ELLIPSES;	
			
		}


    }
}

