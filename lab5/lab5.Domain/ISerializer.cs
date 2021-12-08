using System.Collections.Generic;

namespace lab5.Domain
{
    public interface ISerializer 
    {
        IEnumerable<Building> DeSerializeByLINQ(string fileName);
        IEnumerable<Building> DeSerializeXML(string fileName);
        IEnumerable<Building> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Building> buildings, string fileName);
        void SerializeXML(IEnumerable<Building> buildings, string fileName);
        void SerializeJSON(IEnumerable<Building> buildings, string fileName);
    }
}
