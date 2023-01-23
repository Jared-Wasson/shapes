using System;
namespace strategyShapes
{
	public class EmptyClass
	{
		static void Main(string[] args)
		{
			string fileToProcess = "";
			string locationToSave = "";

			if (args.Length != 2)
			{
				Console.WriteLine("command line arugments are not correct!");
			}

			fileToProcess = args[0];
			locationToSave = args[1];

			if(fileToProcess.Contains(".json"))
			{
                Parsers.JsonParser parser = new Parsers.JsonParser(fileToProcess, locationToSave);
				parser.execute();
            } else if (fileToProcess.Contains(".xml"))
			{
				Parsers.XmlParser parser = new Parsers.XmlParser(fileToProcess, locationToSave);
				parser.execute();
            } else
			{
                Console.WriteLine("command line arugments are not correct!");
            }

		}

	}
		
}

