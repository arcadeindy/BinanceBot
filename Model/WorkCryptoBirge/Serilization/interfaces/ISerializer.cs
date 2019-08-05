using System.Collections.Generic;

namespace Model.Serilization.interfaces
{
    public interface ISerializer<T> where T : class
    {
        IEnumerable<T> DeserializeMany(string json);
        T Deserialize(string json);
        string Serialize(T type);
    }
}
