using System;
using Newtonsoft.Json;
using strategyShapes.Shapes;

namespace strategyShapes.Parsers
{
	public class JsonParser
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

        

		public JsonParser(string filename, string pathToSaveTo)
		{
			this.filename = filename;
            this.pathToSaveTo = pathToSaveTo;
			
		}

		public void execute()

		{
            dynamic? jsonData = getJsonFromFile(filename);

            if (jsonData == null)
            {
                return;
            }
            

			foreach (var item in jsonData.data)
			{
                processShape(item);


                

            }
            printResults();
            writeToCSV(pathToSaveTo);


        }

        public ShapeTypes getShapeType(dynamic item)
		{
			if(item.square != null)
			{
				return ShapeTypes.SQUARE;
			}

            if (item.circle != null)
            {
                return ShapeTypes.CIRCLE;
            }

            if (item.equallateral != null)
            {
                return ShapeTypes.EQUALLATERAL;
            }

            if (item.isosceles != null)
            {
                return ShapeTypes.ISOSCELES;
            }

            if (item.nc_ellipse != null)
            {
                return ShapeTypes.NC_ELLIPSE;
            }

            if (item.rectangle != null)
            {
                return ShapeTypes.RECTANGLE;
            }

            if (item.scalene != null)
            {
                return ShapeTypes.SCALENE;
            }


            return ShapeTypes.NONE;
        }
		



        public Ellipses executeEllipse(ShapeTypes name, double semiMajorAxis, double semiMinorAxis)
        {
            return new Ellipses(name, semiMajorAxis, semiMinorAxis);

        }

        public Rectangle executeRectangle(ShapeTypes name, double length, double width)
        {
            return new Rectangle(name, length, width);

        }

        public Triangle executeTriangle(ShapeTypes name, double side1, double side2, double side3)
        {
            return new Triangle(name, side1, side2, side3);

        }


        public dynamic? getJsonFromFile(string filename)
        {
            try
            {
                string text = File.ReadAllText(filename);
                return Newtonsoft.Json.JsonConvert.DeserializeObject(text);

            } catch (Exception e)
            {
                Console.WriteLine("Could not read file from path given");
            }
            return null;

        }


        public void processShape(dynamic item)
        {
            ShapeTypes shape = getShapeType(item);
            switch (shape)
            {
                case ShapeTypes.CIRCLE:

                    if (item.circle.semiMajorAxis != null && item.circle.semiMinorAxis != null)
                    {
                        try
                        {
                            Ellipses circle = executeEllipse(ShapeTypes.CIRCLE, (double)item.circle.semiMajorAxis, (double)item.circle.semiMinorAxis);
                            circleAera += circle.getArea();
                            ellipsesAera += circle.getArea();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("parameters in json for cirlce is not correct! The calculations will not include this shape");

                        }

                    }
                    break;

                case ShapeTypes.NC_ELLIPSE:
                    if (item.nc_ellipse.semiMajorAxis != null && item.nc_ellipse.semiMinorAxis != null)
                    {
                        try
                        {
                            Ellipses ellipses = executeEllipse(ShapeTypes.NC_ELLIPSE, (double)item.nc_ellipse.semiMajorAxis, (double)item.nc_ellipse.semiMinorAxis);
                            ellipsesAera += ellipses.getArea();
                            nonCircleEllipseAera += ellipses.getArea();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("parameters in json for ellipse is not correct! The calculations will not include this shape");
                        }
                    }

                    break;

                case ShapeTypes.SQUARE:
                    if (item.square.length != null && item.square.width != null)
                    {
                        try
                        {
                            Rectangle square = executeRectangle(ShapeTypes.SQUARE, (double)item.square.length, (double)item.square.width);
                            squareAera += square.getArea();
                            rectangleAera += square.getArea();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("parameters in json for square is not correct! The calculations will not include this shape");
                        }
                    }
                    break;

                case ShapeTypes.RECTANGLE:
                    if (item.rectangle.length != null && item.rectangle.width != null)
                    {
                        try
                        {
                            Rectangle rectangle = executeRectangle(ShapeTypes.SQUARE, (double)item.rectangle.length, (double)item.rectangle.width);
                            nonSquareRectangle += rectangle.getArea();
                            rectangleAera += rectangle.getArea();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("parameters in json for rectangle is not correct! The calculations will not include this shape");
                        }
                    }
                    break;

                case ShapeTypes.ISOSCELES:
                    if (item.isosceles.side1 != null && item.isosceles.side2 != null && item.isosceles.side3 != null)
                    {
                        try
                        {
                            Triangle isosceles = executeTriangle(ShapeTypes.ISOSCELES, (double)item.isosceles.side1, (double)item.isosceles.side2, (double)item.isosceles.side3);
                            isoscelesAera += isosceles.getAera();
                            trianglesAera += isosceles.getAera();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("parameters in json for rectangle is not correct! The calculations will not include this shape");
                        }
                    }
                    break;

                case ShapeTypes.EQUALLATERAL:
                    if (item.equallateral.side1 != null && item.equallateral.side2 != null && item.equallateral.side3 != null)
                    {
                        try
                        {
                            Triangle equallateral = executeTriangle(ShapeTypes.EQUALLATERAL, (double)item.equallateral.side1, (double)item.equallateral.side2, (double)item.equallateral.side3);
                            equallateralAera += equallateral.getAera();
                            trianglesAera += equallateral.getAera();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("parameters in json for rectangle is not correct! The calculations will not include this shape");
                        }
                    }
                    break;

                case ShapeTypes.SCALENE:
                    if (item.scalene.side1 != null && item.scalene.side2 != null && item.scalene.side3 != null)
                    {
                        try
                        {
                            Triangle scalene = executeTriangle(ShapeTypes.SCALENE, (double)item.scalene.side1, (double)item.scalene.side2, (double)item.scalene.side3);
                            scaleneAera += scalene.getAera();
                            trianglesAera += scalene.getAera();
                           

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("parameters in json for rectangle is not correct! The calculations will not include this shape");
                        }
                    }
                    break;
            }
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
            var w = new StreamWriter(wantedLocation + "results.csv");
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

