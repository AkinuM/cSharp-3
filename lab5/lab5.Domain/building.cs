using System;

namespace lab5.Domain
{
	[Serializable]
	public class Building
	{
		public string Name { get; set; }
		public HeatingSystem heatingSystem;

		public Building(string name)
		{
			Name = name;
		}

		public void AddHeatingSystem(HeatingSystem heating)
		{
			heatingSystem = heating;
		}
	}
}
