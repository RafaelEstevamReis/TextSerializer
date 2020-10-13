namespace TextSerializer.Formatters
{
    public class BooleanFormatter : Formatter
    {
        override public string Serialize(SerializableValue Value)
        {
            if ((bool)Value.Object) return "1";
            return "0";
        }
        override public bool Deserialize(string Block, SerializableValue Value)
        {
            Value.Object = (Block == "1");
            return true;
        }
    }
}
