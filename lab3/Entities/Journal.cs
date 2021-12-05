using System;

namespace lab1
{
	class Journal
	{
		MyCustomCollection<string> EventNames = new MyCustomCollection<string>();
		MyCustomCollection<string> Details = new MyCustomCollection<string>();
		public void AddEvent(string eventName, string details)
		{
			EventNames.Add(eventName);
			Details.Add(details);
		}
		public void PrintLogs()
		{
			Console.WriteLine("Journal logs:");
			for (int i = 0; i != EventNames.Count; i++)
			{
				Console.WriteLine(EventNames[i] + " " + Details[i]);
			}
		}
	}
}