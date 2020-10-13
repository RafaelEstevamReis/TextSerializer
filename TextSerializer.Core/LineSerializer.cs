using System;
using System.IO;
using System.Linq;

namespace TextSerializer
{
    public class LineSerializer
    {
        public void Serialize<T>(T Object, StreamWriter stream) where T : new()
        {
            BlockSerializer bs = new BlockSerializer();
            bs.Serialize(Object, stream);
            stream.WriteLine();
            stream.Flush();
        }
        public T Deserialize<T>(StreamReader stream, out SerializationResult Results) where T : new()
        {
            var line = stream.ReadLine();
            return Deserialize<T>(line, out Results);
        }
        //public static SerializationResult Deserialize(object Object, string line)
        public T Deserialize<T>(string line, out SerializationResult Results) where T : new()
        {
            T Object = new T();
            Results = new SerializationResult();
            var data = ObjectInspector.ReadObject(Object);

            for (int idx = data.Min(o => o.Index); idx <= data.Max(o => o.Index); idx++)
            {
                if (!data.Select(o => o.Index).Contains(idx))
                {
                    //throw new InvalidOperationException("Index " + idx + " is missing");
                }
            }

            int offset = 0;
            foreach (var val in data)
            {
                try
                {
                    string block = line.Substring(offset, val.Length);
                    if (val.Formatter.Deserialize(block, val))
                    {
                        Object.GetType().GetProperty(val.Name).SetValue(Object, val.Object);
                    }
                    else
                    {
                        Results.Errors.Add(new Exception("Failed to deserialize field " + val.Name));
                    }
                }
                catch (Exception ex)
                {
                    Results.Errors.Add(new Exception("Error serializing field " + val.Name, ex));
                }
                offset += val.Length;
            }
            return Object;
        }
    }
}
