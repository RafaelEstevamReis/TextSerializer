using System;

namespace TextSerializer.Formatters
{
    public class EnumOfIntFormatter : Formatter
    {
        override public string Serialize(SerializableValue Value)
        {
            var iVal = Convert.ToInt32(Value.Object);
            if (iVal == -1) return " ";

            var sVal = iVal.ToString(new string('0', Value.Length));
            if (sVal.Length > Value.Length) throw new InvalidOperationException();
            return sVal;
        }
        override public bool Deserialize(string Line, int Offset, SerializableValue Value)
        {
            string part = Line.Substring(Offset, Value.Length);
            int iVal;
            if (!Int32.TryParse(part, out iVal))
            {
                iVal = -1;
            }
            Value.Object = iVal; //Value.Type.
            return true;
        }
    }
}
