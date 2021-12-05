using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
	class ATE
	{
		public delegate void AddUsers(User user);
		public event AddUsers NotifyAddUsers;
		public delegate void AddRates(Rate rate);
		public event AddRates NotifyAddRates;
		public delegate void AddCall(string userName, Call call);
		public event AddCall NotifyAddCalls;

		public Dictionary<string, Rate> Rates = new Dictionary<string, Rate>();
		public List<User> Users = new List<User>();

		public void addRate(string name, int price)
		{
			Rate rate = new Rate(name, price);
			Rates.Add(name, rate);
			NotifyAddRates?.Invoke(rate);
		}

		public void addUser(string name)
		{
			User user = new User(name);
			Users.Add(user);
			NotifyAddUsers?.Invoke(user);
		}

		public void addCall(string userName, int duration, Rate rate)
		{
			Call call = new Call(duration, rate);
			int i;
			for(i = 0; i != Users.Count; i++)
			{
				if(userName == Users[i].Name)
				{
					break;
				}
			}
			Users[i].Calls.Add(call);
			NotifyAddCalls?.Invoke(userName, call);
			foreach (var tempRate in Users[i].Rates)
			{
				if (tempRate.Equals(rate))
				{
					return;
				}
			}
			Users[i].Rates.Add(rate);
		}

		public void costOfUserCalls(string name)
		{
			int cost = 0;
			var tempUsers = from user in Users
											select user;
			foreach (var tempUser in tempUsers)
			{
				if (tempUser.Name.Equals(name))
				{
					for (int j = 0; j != tempUser.Calls.Count; j++)
					{
						cost += tempUser.Calls[j].Duration * tempUser.Calls[j].Rate.Price;
					}
					break;
				}
			}
			Console.WriteLine("Cost of " + name + " calls: " + cost);
		}

		public int intCostOfUserCalls(string name)
		{
			int cost = 0;
			var tempUsers = from user in Users
											select user;
			foreach (var tempUser in tempUsers)
			{
				if (tempUser.Name.Equals(name))
				{
					for (int j = 0; j != tempUser.Calls.Count; j++)
					{
						cost += tempUser.Calls[j].Duration * tempUser.Calls[j].Rate.Price;
					}
					break;
				}
			}
			return cost;
		}

		public void costOfAllCalls()
		{
			int cost = 0;
			var tempUsers = from user in Users
											select user;
			foreach (var tempUser in tempUsers)
			{
				for (int i = 0; i != tempUser.Calls.Count; i++)
				{
					cost += tempUser.Calls[i].Duration * tempUser.Calls[i].Rate.Price;
				}
			}
			Console.WriteLine("Cost of all calls: " + cost);
		}

		public void viewRates()
		{
			var sortRates = from rate in Rates
											orderby rate.Value.Price descending 
											select rate;
			foreach (var tempRate in sortRates)
			{
				Console.WriteLine(tempRate.Key + " " + tempRate.Value.Price);
			}
		}

		public void viewUsers()
		{
			for (int i = 0; i != Users.Count; i++)
			{
				Console.WriteLine(Users[i].Name);
			}
		}

		public void mostCostOfUserCalls()
		{
			var sortUsers = from user in Users
											orderby intCostOfUserCalls(user.Name) descending
											select user;
			foreach (var tempUser in sortUsers)
			{
				Console.WriteLine(tempUser.Name + " " + intCostOfUserCalls(tempUser.Name));
				break;
			}
		}

		public void countUsersPaidMoreThan(int sum)
		{
			var count = Users.Aggregate(0, (tempCount, user) => intCostOfUserCalls(user.Name) > sum ? tempCount + 1 : tempCount);
			Console.WriteLine(count);
		}

		public void listCostOfUserCallsByRates(string name)
		{
			foreach (var user in Users)
			{
				if (user.Name.Equals(name))
				{
					var ratesGroups = user.Calls.GroupBy(call => call.Rate.Name);
					foreach (var group in ratesGroups)
					{
						Console.WriteLine(group.Key);
						foreach (var calls in group)
						{
							Console.WriteLine(calls.Duration * calls.Rate.Price);
						}
					}
					break;
				}
			}
		}
	}
}
