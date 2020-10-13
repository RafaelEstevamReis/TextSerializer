using System;

namespace TextSerializer.Formatters
{
    public class DecimalFormatter : Formatter
    {
        override public string Serialize(SerializableValue Value)
        {
            var dVal = Convert.ToDecimal(Value.Object);

            int inteiros = Value.Length - Value.Decimals;
            if (dVal < 0) inteiros--;
            string mascara = new string('0', inteiros) + "." + new string('0', Value.Decimals);

            var sVal = dVal.ToString(mascara, System.Globalization.CultureInfo.InvariantCulture).Replace(".", "");
            if (sVal.Length > Value.Length) throw new InvalidOperationException();

            return sVal;
        }
        override public bool Deserialize(string Block, SerializableValue Value)
        {
            decimal dVal = Convert.ToDecimal(Block);

            int Div = (int)Math.Pow(10, Value.Decimals);
            Value.Object = dVal / Div;

            return true;
        }
    }
}
