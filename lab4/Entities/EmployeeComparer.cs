using System.Collections.Generic;

namespace FileService.Entities
{
    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee first, Employee second) => first.Name.CompareTo(second.Name);
    }
}