using System;
using TextSerializer.Formatters;

namespace TextSerializer
{
    public class SerializableValue
    {
        public object Object { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public DataType Tipo { get; set; }
        public int Length { get; set; }
        public int Decimals { get; set; }
        public Type Type { get; set; }
        public IFormatter Formatter { get; set; }

        public override string ToString()
        {
            if (Tipo == DataType.Skip) return Name + " [SKIP]";
            return string.Format("{0} [{2}] {1}", Name, Object == null ? "[NULL]" : Object.ToString(), Tipo.ToString());
        }
    }
}
