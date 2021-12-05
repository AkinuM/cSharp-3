using System;
using System.Collections.Generic;


namespace lab1
{
	class User
	{
		public string Name;
		public List<Call> Calls = new List<Call>();
		public List<Rate> Rates = new List<Rate>();

		public User(string name)
		{
			Name = name;
		}
	}
}
