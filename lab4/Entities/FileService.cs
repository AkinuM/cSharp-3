using FileService.Interfaces;
using System.Collections.Generic;
using System.IO;


namespace FileService.Entities
{
    class MyFileService : IFileService
    {
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    int age = reader.ReadInt32();
                    bool isWorking = reader.ReadBoolean();

                    yield return new Employee(age, name, isWorking);
                }
            }
        }
        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                foreach (Employee employee in data)
                {
                    writer.Write(employee.Name);
                    writer.Write(employee.Age);
                    writer.Write(employee.IsWorking);
                }
            }
        }
    }
}
