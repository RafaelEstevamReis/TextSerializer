namespace TextSerializer.Formatters;

public class StringFormatter : Formatter
{
    override public string Serialize(SerializableValue Value)
    {
        string sVal = Value.Object as string;

        if (string.IsNullOrEmpty(sVal)) return new string(' ', Value.Length);

        // equal size, returns itself
        if (sVal.Length == Value.Length) return sVal;
        // bigger: truncate
        if (sVal.Length > Value.Length) return sVal.Substring(0, Value.Length);
        // smaller, pad
        return sVal.PadRight(Value.Length);
    }
    override public bool Deserialize(string Block, SerializableValue Value)
    {
        Value.Object = Block.TrimEnd();
        return true;
    }
}
