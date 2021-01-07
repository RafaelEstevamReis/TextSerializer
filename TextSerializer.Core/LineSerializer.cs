using System;
using System.IO;

namespace TextSerializer
{
    public class LineSerializer
    {
        public event EventHandler<SerializableValue[]> ObjectReadComplete;

        public void Serialize<T>(T Object, StreamWriter stream) where T : new()
        {
            BlockSerializer bs = new BlockSerializer();
            if (ObjectReadComplete != null)
            {
                bs.ObjectReadComplete += ObjectReadComplete;
            }
            bs.Serialize(Object, stream);
            stream.WriteLine();
            stream.Flush();
        }
        public T Deserialize<T>(StreamReader stream, out SerializationResult Results) where T : new()
        {
            var line = stream.ReadLine();
            return Deserialize<T>(line, out Results);
        }
        public T Deserialize<T>(string line, out SerializationResult Results) where T : new()
        {
            var bs = new BlockSerializer();
            
            if (ObjectReadComplete != null)
            {
                bs.ObjectReadComplete += ObjectReadComplete;
            }

            return bs.Deserialize<T>(new StringReader(line), out Results);
        }
    }
}
