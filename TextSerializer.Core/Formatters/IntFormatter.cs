using System;

namespace TextSerializer.Formatters
{
    public class IntFormatter : Formatter
    {
        override public string Serialize(SerializableValue Value)
        {
            var iVal = Convert.ToInt32(Value.Object);

            var sVal = iVal.ToString(new string('0', Value.Length));
            if (sVal.Length > Value.Length) throw new InvalidOperationException();
            return sVal;
        }
        override public bool Deserialize(string Block, SerializableValue Value)
        {
            Value.Object = Convert.ToInt32(Block);
            return true;
        }
    }
}
