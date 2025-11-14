namespace TextSerializer.Formatters;

public interface IFormatter
{
    SerializationOptions Options { get; }
    string Serialize(SerializableValue Value);
    bool Deserialize(string Block, SerializableValue Value);
}
