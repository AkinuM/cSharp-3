using System;

namespace lab5.Domain
{
	[Serializable]
	public class HeatingSystem
	{
		public string Type { get; set; }

		public HeatingSystem(string type)
		{
			Type = type;
		}
	}
}
