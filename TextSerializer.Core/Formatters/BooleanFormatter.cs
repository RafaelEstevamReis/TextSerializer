namespace TextSerializer.Formatters
{
    public class BooleanFormatter : Formatter
    {
        override public string Serialize(SerializableValue Value)
        {
            if ((bool)Value.Object) return "1";
            return "0";
        }
        override public bool Deserialize(string Line, int Offset, SerializableValue Value)
        {
            string part = Line.Substring(Offset, Value.Length);
            Value.Object = (part == "1");
            return true;
        }
    }
}
