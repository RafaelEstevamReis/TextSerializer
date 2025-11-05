namespace TextSerializer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TextSerializer.Attributes;

public class ObjectInspector
{
    public static SerializableValue[] ReadObject<T>(T Object, SerializationOptions options) where T : new()
    {
        var myType = Object.GetType();
        IList<PropertyInfo> props = [.. myType.GetProperties()];
        Dictionary<int, SerializableValue> dicProps = [];

        foreach (var prop in props)
        {
            if (prop.GetCustomAttributes(typeof(IgnoreAttribute), true).Any()) continue;

            var typeProp = DataType.Skip;

            var lenProp = checkProperty<LengthAttribute>(myType, prop);
            typeProp = checkProperty<TypeAttribute>(myType, prop).Type;
            var indexProp = checkProperty<IndexAttribute>(myType, prop);

            if (dicProps.ContainsKey(indexProp.Index))
            {
                throw new InvalidOperationException("IndexAttribute can not be duplicate " + myType.Name + "." + prop.Name + ", Index:" + indexProp.Index);
            }

            object propVal = prop.GetValue(Object);
            var formatter = Formatters.Formatter.GetNativeFormatter(typeProp, prop.PropertyType);
            if (formatter == null) throw new InvalidOperationException("None Formatter matched " + myType.Name + "." + prop.Name + ", Index:" + indexProp.Index);

            formatter.Options = options;

            dicProps.Add(indexProp.Index, new SerializableValue()
            {
                Name = prop.Name,
                Index = indexProp.Index,
                Length = lenProp.Length,
                Decimals = lenProp.Decimals,
                Tipo = typeProp,
                Object = propVal,
                Type = prop.PropertyType,
                Formatter = formatter,
            });
        }

        var result = dicProps.OrderBy(x => x.Key).Select(x => x.Value).ToArray();

        var regSize = GetRegistrySizeAttribute<T>();
        if (regSize != null)
        {
            var itemsSize = result.Sum(o => o.Length);
            if (itemsSize != regSize.Length)
            {
                throw new InvalidOperationException($"Registry with total Length mismatch. Sum of properties' len: {itemsSize} Expected: {regSize.Length}");
            }
        }

        return result;
    }
    private static T checkProperty<T>(Type myType, PropertyInfo prop)
    {
        var p = prop.GetCustomAttributes(typeof(T), true).Cast<T>().FirstOrDefault();
        if (p == null)
        {
            throw new InvalidOperationException("Public properties must be marked with " + typeof(T).Name + " or IgnoreAttribute. " + myType.Name + "." + prop.Name);
        }
        return p;
    }

    public static RegistrySizeAttribute GetRegistrySizeAttribute<T>()
    {
        var typeT = typeof(T);
        var att = typeT.GetCustomAttribute(typeof(RegistrySizeAttribute));
        return att as RegistrySizeAttribute;
    }
}
