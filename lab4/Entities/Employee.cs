namespace FileService.Entities
{
    public class Employee
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public bool IsWorking { get; set; }

        public Employee(int age, string name, bool isWorking)
        {
            Age = age;
            Name = name;
            IsWorking = isWorking;
        }
		}
}
