using System;
using System.Collections.Generic;
using lab5.Domain;
using Serializer;

namespace lab5
{
	class Program
	{
		static void Main(string[] args)
		{
			MySerializer serializer = new MySerializer();
			List<Building> buildings = new List<Building>();

			Building building1 = new Building("Building1");
			building1.AddHeatingSystem(new HeatingSystem("HeatingSystem1"));
			buildings.Add(building1);

			Building building2 = new Building("Building2");
			building1.AddHeatingSystem(new HeatingSystem("HeatingSystem2"));
			buildings.Add(building2);

			Building building3 = new Building("Building3");
			building1.AddHeatingSystem(new HeatingSystem("HeatingSystem3"));
			buildings.Add(building3);

			Building building4 = new Building("Building4");
			building1.AddHeatingSystem(new HeatingSystem("HeatingSystem4"));
			buildings.Add(building4);

			Building building5 = new Building("Building5");
			building1.AddHeatingSystem(new HeatingSystem("HeatingSystem5"));
			buildings.Add(building5);

			serializer.SerializeByLINQ(buildings, "LINQ-to-XML.xml");
			var newBuildings = serializer.DeSerializeByLINQ("LINQ-to-XML.xml");
			Console.WriteLine("LINQ-to-XML");
			foreach (Building building in newBuildings)
			{
				Console.WriteLine(building.Name + " " + building.heatingSystem.Type);
			}
			Console.WriteLine();

			serializer.SerializeJSON(buildings, "JsonFile.json");
			newBuildings = serializer.DeSerializeJSON("JsonFile.json");
			Console.WriteLine("JSON");
			foreach (Building building in newBuildings)
			{
				Console.WriteLine(building.Name + " " + building.heatingSystem.Type);
			}
			Console.WriteLine();

			serializer.SerializeXML(buildings, "HMLFile.xml");
			newBuildings = serializer.DeSerializeXML("HMLFile.xml");
			Console.WriteLine("HML");
			foreach (Building building in newBuildings)
			{
				Console.WriteLine(building.Name + " " + building.heatingSystem.Type);
			}
		}
	}
}
