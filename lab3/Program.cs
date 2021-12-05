using System;

namespace lab1
{
	class Program
	{
		static void Main(string[] args)
		{
			ATE ate = new ATE();
			Journal jour = new Journal();
			ate.NotifyAddUsers += delegate (User user)
			{
				jour.AddEvent("New user", user.Name);
			};
			ate.NotifyAddRates += delegate (Rate rate)
			{
				jour.AddEvent("New rate", rate.Name + " " + rate.Price);
			};
			ate.NotifyAddCalls += (string userName, Call call) => Console.WriteLine(userName + " " + call.Duration + " " + call.Rate.Name);
			ate.addRate("in", 2);
			ate.addRate("out", 3);
			ate.addUser("AD");
			ate.addUser("A");
			ate.addCall("AD", 3, ate.Rates["in"]);
			ate.addCall("AD", 4, ate.Rates["in"]);
			ate.addCall("AD", 5, ate.Rates["out"]);
			ate.addCall("AD", 6, ate.Rates["out"]);
			ate.addCall("A", 5, ate.Rates["out"]);
			ate.costOfUserCalls("A");
			ate.costOfUserCalls("AD");
			ate.costOfAllCalls();
			ate.viewRates();
			ate.viewUsers();
			jour.PrintLogs();
			ate.mostCostOfUserCalls();
			ate.countUsersPaidMoreThan(15);
			ate.listCostOfUserCallsByRates("AD");
		}
	}
}
