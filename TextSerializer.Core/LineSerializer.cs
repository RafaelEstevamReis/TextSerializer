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
            var bs = new BlockSerializer();
            return bs.Deserialize<T>(new StringReader(line), out Results);
        }
    }
}
