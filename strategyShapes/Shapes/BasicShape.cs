using System;
namespace strategyShapes.Shapes
{
	public class BasicShape
	{
		public ShapeTypes name;
		public BasicShape(ShapeTypes name)
		{
			this.name = name;
		}

		public ShapeTypes getName()
		{
			return this.name;
		}

		public void getParent()
		{

		}
	}
}

