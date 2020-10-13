using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TextSerializer
{
    public class BlockSerializer
    {
        public static void Serialize(object Object, StreamWriter stream)
        {
            var data = ObjectInspector.ReadObject(Object);
            foreach (var val in data)
            {
                string value = val.Formatter.Serialize(val);
                if (value.Length != val.Length) throw new InvalidOperationException("Serialized Length mismatch");
                stream.Write(value);
            }
            stream.Flush();
        }
        public static SerializationResult Deserialize(object Object, StreamReader stream)
        {
            var line = stream.ReadLine();
            return Deserialize(Object, line);
        }
        public static SerializationResult Deserialize(object Object, string line)
        {
            var serResult = new SerializationResult();
            var data = ObjectInspector.ReadObject(Object);

            int offset = 0;
            foreach (var val in data)
            {
                try
                {
                    if (val.Formatter.Deserialize(line, offset, val))
                    {
                        Object.GetType().GetProperty(val.Name).SetValue(Object, val.Object);
                    }
                    else
                    {
                        serResult.Errors.Add(new Exception("Failed to deserialize field " + val.Name));
                    }
                }
                catch (Exception ex)
                {
                    serResult.Errors.Add(new Exception("Error serializing field " + val.Name, ex));
                }
                offset += val.Length;
            }
            return serResult;
        }
    }
}
