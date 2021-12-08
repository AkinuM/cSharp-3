using System;
using lab5.Domain;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;

namespace Serializer
{
	public class MySerializer : ISerializer
	{
		public IEnumerable<Building> DeSerializeByLINQ(string fileName)
		{
			XDocument document = XDocument.Load(fileName);
			List<Building> buildings = new List<Building>();
			foreach (XElement elementBuilding in document.Root.Elements("Building"))
			{
				Building building = new Building((string)elementBuilding.Attribute("Name"));
				string heatingSystemType = (string)elementBuilding.Element("Type");
				HeatingSystem heatingSystem = new HeatingSystem(heatingSystemType);
				building.AddHeatingSystem(heatingSystem);
				buildings.Add(building);
			}
			return buildings;
		}
		public IEnumerable<Building> DeSerializeXML(string fileName)
		{
			XmlSerializer formater = new XmlSerializer(typeof(List<Building>));
			using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
			{
				return (List<Building>)formater.Deserialize(fileStream);
			}
		}
		public IEnumerable<Building> DeSerializeJSON(string fileName)
		{
			string data = File.ReadAllText(fileName);
			return JsonSerializer.Deserialize<List<Building>>(data);
		}
		public void SerializeByLINQ(IEnumerable<Building> buildings, string fileName)
		{
			XDocument document = new XDocument();
			XElement elementBuildings = new XElement("Buildings");
			foreach (Building building in buildings)
			{
				XElement elementBuilding = new XElement("Building", new XAttribute("Name", building.Name));
				XElement heatingSystem = new XElement("HeatingSystem", new XAttribute("Type", building.heatingSystem.Type));
				elementBuilding.Add(heatingSystem);
				elementBuildings.Add(elementBuilding);
			}
			document.Add(elementBuildings);
			document.Save(fileName);
		}
		public void SerializeXML(IEnumerable<Building> buildings, string fileName)
		{
			XmlSerializer formater = new XmlSerializer(typeof(List<Building>));
			using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
			{
				formater.Serialize(fileStream, buildings);
			}
		}
		public void SerializeJSON(IEnumerable<Building> buildings, string fileName)
		{
			string data = JsonSerializer.Serialize(buildings);
			File.WriteAllText(fileName, data);
		}
	}
}
