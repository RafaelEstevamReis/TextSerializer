namespace TextSerializer.Formatters;

using System;

public abstract class Formatter : IFormatter
{
    public static Formatter GetNativeFormatter(DataType TipoDados, Type type)
    {
        if (TipoDados == DataType.Skip) return new SkipFormatter();
        if (TipoDados == DataType.C && type == typeof(string)) return new StringFormatter();

        if (TipoDados == DataType.C && type == typeof(int)) return new IntFormatter();
        if (TipoDados == DataType.N && type == typeof(int)) return new IntFormatter();

        if (TipoDados == DataType.C && type == typeof(DateTime)) return new DateTimeFormatter();
        if (TipoDados == DataType.N && type == typeof(DateTime)) return new DateTimeFormatter();

        if (TipoDados == DataType.N && type == typeof(decimal)) return new DecimalFormatter();

        if (TipoDados == DataType.N && type == typeof(bool)) return new BooleanFormatter();

        if (type.IsEnum)
        {
            if (TipoDados == DataType.N) // int
            {
                return new EnumOfIntFormatter();
            }

        }

        if (TipoDados == DataType.C && type == typeof(object)) return new StringFormatter();

        //throw new NotImplementedException();
        return new StringFormatter();
    }

    public SerializationOptions Options { get; set; }

    public abstract string Serialize(SerializableValue Value);
    //public abstract bool Deserialize(string Line, int Offset, SerializableValue Value);
    public abstract bool Deserialize(string Block, SerializableValue Value);
}
