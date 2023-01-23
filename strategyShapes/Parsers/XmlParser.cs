using System;
using System.Xml;
using System.Xml.Linq;

namespace strategyShapes.Parsers
{
	public class XmlParser
	{
		string filename;
        string pathToSaveTo;
        double totalAera = 0;
        double ellipsesAera = 0;
        double circleAera = 0;
        double nonCircleEllipseAera = 0;
        double convexPolygonsAera = 0;
        double trianglesAera = 0;
        double isoscelesAera = 0;
        double scaleneAera = 0;
        double equallateralAera = 0;
        double rectangleAera = 0;
        double squareAera = 0;
        double nonSquareRectangle = 0;

        public XmlParser(string filename, string pathToSaveTo)
		{
			this.filename = filename;
            this.pathToSaveTo = pathToSaveTo;
		}

		public void execute()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filename);
			foreach (XmlNode node in xmlDocument.DocumentElement)
			{
				processNode(node);
				
            }

            printResults();
            writeToCSV(this.pathToSaveTo);
        }

		public void processNode(XmlNode node)
		{
			switch (node.Name)
			{
				case "circle":

					if (ellipseNodeValidation(node))
                    {
                        Shapes.Ellipses circle =  createEllipse(node);
                        circleAera += circle.getArea();
                        ellipsesAera += circle.getArea();
                    } else
                    {
                        Console.WriteLine("XML fields are not correct for cirlce, this shape will not be used in the calculation");
                    }
                    

					break;

                case "nc_ellipse":

                    if (ellipseNodeValidation(node))
                    {
                        Shapes.Ellipses ellipse = createEllipse(node);
                        nonCircleEllipseAera += ellipse.getArea();
                        ellipsesAera += ellipse.getArea();
                    }
                    else
                    {
                        Console.WriteLine("XML fields are not correct for ellipse, this shape will not be used in the calculation");
                    }


                    break;

                case "rectangle":

                    if (rectangleNodeValidation(node))
                    {
                        Shapes.Rectangle rectangle = createRectangle(node);
                        rectangleAera += rectangle.getArea();
                        nonSquareRectangle += rectangle.getArea();
                        
                    }
                    else
                    {
                        Console.WriteLine("XML fields are not correct for rectangle, this shape will not be used in the calculation");
                    }


                    break;

                case "square":

                    if (rectangleNodeValidation(node))
                    {
                        Shapes.Rectangle square = createRectangle(node);
                        rectangleAera += square.getArea();
                        squareAera += square.getArea();
                  
                    }
                    else
                    {
                        Console.WriteLine("XML fields are not correct for square, this shape will not be used in the calculation");
                    }


                    break;

                case "equallaterial":

                    if (triangleNodeValidation(node))
                    {
                        Shapes.Triangle equallaterial = createTriangle(node);
                        trianglesAera += equallaterial.getAera();
                        equallateralAera += equallaterial.getAera();
                        
                    }
                    else
                    {
                        Console.WriteLine("XML fields are not correct for equallateral, this shape will not be used in the calculation");
                    }


                    break;

                case "isosecles":

                    if (triangleNodeValidation(node))
                    {
                        Shapes.Triangle isosecles = createTriangle(node);
                        trianglesAera += isosecles.getAera();
                        isoscelesAera += isosecles.getAera();
                        

                    }
                    else
                    {
                        Console.WriteLine("XML fields are not correct for isosecles, this shape will not be used in the calculation");
                    }


                    break;

                case "scalene":

                    if (triangleNodeValidation(node))
                    {
                        Shapes.Triangle scalene = createTriangle(node);
                        trianglesAera += scalene.getAera();
                        scaleneAera += scalene.getAera();
                        

                    }
                    else
                    {
                        Console.WriteLine("XML fields are not correct for scalene, this shape will not be used in the calculation");
                    }


                    break;
            }
		}

		public bool ellipseNodeValidation(XmlNode node)
		{
            double semiMajorAxis = 0;
            double semiMinorAxis = 0;

            try
            {
                foreach (XmlNode childNode in node)
                {
                    if (childNode.Name == "semiMajorAxis")
                    {
                        semiMajorAxis = Double.Parse(childNode.InnerText);
                    }
                    if (childNode.Name == "semiMinorAxis")
                    {
                        semiMinorAxis = Double.Parse(childNode.InnerText);
                    }
                }

                if (semiMajorAxis != 0 && semiMinorAxis != 0)
                {
                    return true;

                }

            }
            catch (Exception e)
            {
                return false;
            }
            return false;

        }

        public Shapes.Ellipses createEllipse(XmlNode node)
        {
            double semiMajorAxis = 0;
            double semiMinorAxis = 0;

          
                foreach (XmlNode childNode in node)
                {
                    if (childNode.Name == "semiMajorAxis")
                    {
                        semiMajorAxis = Double.Parse(childNode.InnerText);
                    }
                    if (childNode.Name == "semiMinorAxis")
                    {
                        semiMinorAxis = Double.Parse(childNode.InnerText);
                    }
                }

             return new Shapes.Ellipses(ShapeTypes.CIRCLE, semiMajorAxis, semiMinorAxis);

        }


        public bool rectangleNodeValidation(XmlNode node)
        {
            double length = 0;
            double width = 0;

            try
            {
                foreach (XmlNode childNode in node)
                {
                    if (childNode.Name == "length")
                    {
                        length = Double.Parse(childNode.InnerText);
                    }
                    if (childNode.Name == "width")
                    {
                        width = Double.Parse(childNode.InnerText);
                    }
                }

                if (length != 0 && width != 0)
                {
                    return true;

                }

            }
            catch (Exception e)
            {
                return false;
            }
            return false;

        }




        public Shapes.Rectangle createRectangle(XmlNode node)
        {
            double length = 0;
            double width = 0;

            foreach (XmlNode childNode in node)
            {
                if (childNode.Name == "length")
                {
                    length = Double.Parse(childNode.InnerText);
                }
                if (childNode.Name == "width")
                {
                    width = Double.Parse(childNode.InnerText);
                }
            }

            return new Shapes.Rectangle(ShapeTypes.RECTANGLE, length, width);

        }

        public bool triangleNodeValidation(XmlNode node)
        {
            double side1 = 0;
            double side2 = 0;
            double side3 = 0;

            try
            {
                foreach (XmlNode childNode in node)
                {
                    if (childNode.Name == "side1")
                    {
                        side1 = Double.Parse(childNode.InnerText);
                    }
                    if (childNode.Name == "side2")
                    {
                        side2 = Double.Parse(childNode.InnerText);
                    }
                    if (childNode.Name == "side3")
                    {
                        side3 = Double.Parse(childNode.InnerText);
                    }
                }

                if (side1 != 0 && side2 != 0 && side3 != 0)
                {
                    return true;

                }

            }
            catch (Exception e)
            {
                return false;
            }
            return false;

        }

        public Shapes.Triangle createTriangle(XmlNode node)
        {
            double side1 = 0;
            double side2 = 0;
            double side3 = 0;

            foreach (XmlNode childNode in node)
            {
                if (childNode.Name == "side1")
                {
                    side1 = Double.Parse(childNode.InnerText);
                }
                if (childNode.Name == "side2")
                {
                    side2 = Double.Parse(childNode.InnerText);
                }
                if (childNode.Name == "side3")
                {
                    side3 = Double.Parse(childNode.InnerText);
                }
            }

            return new Shapes.Triangle(ShapeTypes.EQUALLATERAL, side1, side2, side3);

        }

        public void printResults()
        {
            Console.WriteLine("Area Report");
            Console.WriteLine("Total Shape Area: " + (ellipsesAera + rectangleAera + trianglesAera));
            Console.WriteLine("Ellipses: " + ellipsesAera);
            Console.WriteLine("     Circles: " + circleAera);
            Console.WriteLine("     Non-Circle Ellipses: " + nonCircleEllipseAera);
            Console.WriteLine("Concex Polygons: " + (trianglesAera + rectangleAera));
            Console.WriteLine(" Triangles: " + trianglesAera);
            Console.WriteLine("     Isosceles: " + isoscelesAera);
            Console.WriteLine("     Scalene: " + scaleneAera);
            Console.WriteLine("     Equallateral: " + equallateralAera);
            Console.WriteLine(" Rectangles: " + rectangleAera);
            Console.WriteLine("     Squares: " + squareAera);
            Console.WriteLine("     Non-Square Rectangle: " + nonSquareRectangle);
        }

        public void writeToCSV(string wantedLocation)
        {
            var w = new StreamWriter("test-results.csv");
            //header
            var line = string.Format("{0},{1}", "Shape", "Area");
            w.WriteLine(line);
            //all
            line = string.Format("{0},{1}", "All Shapes", (ellipsesAera + rectangleAera + trianglesAera));
            w.WriteLine(line);
            //all ellipses
            line = string.Format("{0},{1}", "All Ellipses", ellipsesAera);
            w.WriteLine(line);
            // cirlces
            line = string.Format("{0},{1}", "Circles", circleAera);
            w.WriteLine(line);
            // non circle
            line = string.Format("{0},{1}", "Non-Circle Ellipses", nonCircleEllipseAera);
            w.WriteLine(line);
            //Convex
            line = string.Format("{0},{1}", "All Convex Polygons", trianglesAera + rectangleAera);
            w.WriteLine(line);
            //triangles
            line = string.Format("{0},{1}", "All Triangles", trianglesAera);
            w.WriteLine(line);
            //Isosceles
            line = string.Format("{0},{1}", "Isosceles", isoscelesAera);
            w.WriteLine(line);
            //Scalene
            line = string.Format("{0},{1}", "Scalene", scaleneAera);
            w.WriteLine(line);
            //equallateral
            line = string.Format("{0},{1}", "Equallateral", equallateralAera);
            w.WriteLine(line);
            //rectangles
            line = string.Format("{0},{1}", "All Rectangles", rectangleAera);
            w.WriteLine(line);
            //rectangles
            line = string.Format("{0},{1}", "Squares", squareAera);
            w.WriteLine(line);
            //rectangles
            line = string.Format("{0},{1}", "Non-Square Rectangle", nonSquareRectangle);
            w.WriteLine(line);
            w.Flush();

        }

    }

}

