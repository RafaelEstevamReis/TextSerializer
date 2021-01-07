using System;

namespace TextSerializer.Formatters
{
    public class DateTimeFormatter : Formatter
    {
        override public string Serialize(SerializableValue Value)
        {
            var dtVal = Convert.ToDateTime(Value.Object);

            var sVal = dtVal.ToString(Options?.DateTimeFormat ?? "s");
            return sVal;
        }
        override public bool Deserialize(string Block, SerializableValue Value)
        {
            if (Options?.DateTimeFormat == null)
            {
                Value.Object = DateTime.Parse(Block);
            }
            else
            {
                Value.Object = DateTime.ParseExact(Block, Options.DateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
            }
            return true;
        }
    }
}
