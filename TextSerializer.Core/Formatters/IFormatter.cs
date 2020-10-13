namespace TextSerializer.Formatters
{
    public interface IFormatter
    {
        string Serialize(SerializableValue Value);
        bool Deserialize(string Line, int Offset, SerializableValue Value);
    }
}
