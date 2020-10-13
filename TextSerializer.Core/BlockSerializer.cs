using System;
using System.IO;
using System.Linq;

namespace TextSerializer
{
    public class BlockSerializer
    {
        public string FieldSeparator { get; set; }
        public bool LastFieldHasSeparator { get; set; }

        public void Serialize<T>(T Object, TextWriter stream) where T : new()
        {
            var data = ObjectInspector.ReadObject(Object);

            for (int i = 0; i < data.Length; i++)
            {
                var val = data[i];
                string value = val.Formatter.Serialize(val);
                if (value.Length != val.Length) throw new InvalidOperationException("Serialized Length mismatch");
                stream.Write(value);

                bool checkSeparator = !string.IsNullOrEmpty(FieldSeparator);
                if (!LastFieldHasSeparator && i == data.Length - 1) checkSeparator = false;

                if (checkSeparator)
                {
                    stream.Write(FieldSeparator);
                }
            }
            stream.Flush();
        }

        public T Deserialize<T>(TextReader stream, out SerializationResult Results) where T : new()
        {
            T Object = new T();
            Results = new SerializationResult();
            var data = ObjectInspector.ReadObject<T>(Object);

            int maxFieldLen = data.Max(o => o.Length);
            if (FieldSeparator != null) maxFieldLen = Math.Max(maxFieldLen, FieldSeparator.Length);
            char[] buffer = new char[maxFieldLen];

            for(int i = 0; i < data.Length;i++)
            {
                var val = data[i];
                try
                {
                    int len = stream.ReadBlock(buffer, 0, val.Length);
                    var block = new String(buffer, 0, len);

                    if (val.Formatter.Deserialize(block, val))
                    {
                        Object.GetType().GetProperty(val.Name).SetValue(Object, val.Object);
                    }
                    else
                    {
                        Results.Errors.Add(new Exception("Failed to deserialize field " + val.Name));
                    }

                    bool checkSeparator = !string.IsNullOrEmpty(FieldSeparator);
                    if (!LastFieldHasSeparator && i == data.Length - 1) checkSeparator = false;

                    if (checkSeparator)
                    {
                        stream.ReadBlock(buffer, 0, FieldSeparator.Length);
                        block = new String(buffer, 0, FieldSeparator.Length);

                        if (block != FieldSeparator)
                        {
                            Results.Errors.Add(new Exception("Missing field separator" + val.Name));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Results.Errors.Add(new Exception("Error serializing field " + val.Name, ex));
                }
            }
            return Object;
        }
    }
}
