using System;
using System.Collections.Generic;
using FileService.Entities;
using System.IO;
using System.Linq;

namespace FileService
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Employee> employees = new List<Employee>();
			employees.Add(new Employee(20, "E", true));
			employees.Add(new Employee(25, "D", false));
			employees.Add(new Employee(30, "C", true));
			employees.Add(new Employee(35, "B", false));
			employees.Add(new Employee(40, "A", true));

			MyFileService fileService = new MyFileService();

			fileService.SaveData(employees, "Employes.txt");

			File.Move("Employes.txt", "NewEmployes.txt");

			IEnumerable<Employee> newEmployess = new List<Employee>();

			newEmployess = fileService.ReadFile("NewEmployes.txt");

			var sortEmployees = newEmployess.OrderBy(employee => employee, new EmployeeComparer());

			foreach (var employee in employees)
			{
				Console.WriteLine(employee.Name + " " + employee.Age + " " + employee.IsWorking);
			}

			Console.WriteLine();

			foreach (var employee in sortEmployees)
			{
				Console.WriteLine(employee.Name + " " + employee.Age + " " + employee.IsWorking);
			}

			File.Delete("NewEmployes.txt");
		}
	}
}
