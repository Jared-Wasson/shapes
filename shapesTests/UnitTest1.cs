namespace strategyShapes;



[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void getEllipsesName()
    {
        Shapes.Ellipses ellipses = new Shapes.Ellipses(ShapeTypes.NC_ELLIPSE, 5, 5);
        Assert.AreEqual(ellipses.getName(), ShapeTypes.NC_ELLIPSE);
    }

    [TestMethod]
    public void getEllipsesArea()
    {
        Shapes.Ellipses ellipses = new Shapes.Ellipses(ShapeTypes.NC_ELLIPSE, 5, 5);
        Assert.AreEqual(ellipses.getArea(), 78.53981633974483);
    }

    [TestMethod]
    public void getRectangleName()
    {
        Shapes.Rectangle rectangle = new Shapes.Rectangle(ShapeTypes.SQUARE, 5, 5);
        Assert.AreEqual(ShapeTypes.SQUARE, rectangle.getName());
    }

    [TestMethod]
    public void getRectangleArea()
    {
        Shapes.Rectangle rectangle = new Shapes.Rectangle(ShapeTypes.SQUARE, 5, 5);
        Assert.AreEqual(rectangle.getArea(), 25);
    }

    [TestMethod]
    public void getTriangleName()
    {
        Shapes.Triangle triangle = new Shapes.Triangle(ShapeTypes.EQUALLATERAL, 5,5,5);
        Assert.AreEqual(ShapeTypes.EQUALLATERAL, triangle.getName());
    }

    [TestMethod]
    public void getTriangleArea()
    {
        Shapes.Triangle triangle = new Shapes.Triangle(ShapeTypes.EQUALLATERAL, 5, 5, 5);
        Assert.AreEqual(triangle.getAera() , 10.825317547305483);
    }
}
