using strategyShapes;
using strategyShapes.Shapes;

namespace strategyShapes.Shapes;

public class Rectangle
{
    double length;
    double width;
    ShapeTypes name;

    public Rectangle(ShapeTypes name, double length, double width)
    {
        this.length = length;
        this.width = width;
        this.name = name;
    }

    public double getArea() {
        return this.length * this.width;
    }

    public ShapeTypes getName()
    {
        return name;
    }

    public ParentShapes getParent()
    {
       return ParentShapes.RECTANGLES;
    }
}