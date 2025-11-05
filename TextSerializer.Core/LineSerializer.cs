namespace TextSerializer;

using System;
using System.IO;

public class LineSerializer
{
    public SerializationOptions Options { get; }

    public event EventHandler<SerializableValue[]> ObjectReadComplete;
    public LineSerializer(SerializationOptions options = null)
    {
        Options = options ?? new SerializationOptions();
    }

    public void Serialize<T>(T Object, StreamWriter stream) where T : new()
    {
        BlockSerializer bs = new BlockSerializer(Options);
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
        var bs = new BlockSerializer(Options);
        
        if (ObjectReadComplete != null)
        {
            bs.ObjectReadComplete += ObjectReadComplete;
        }

        var regSize = ObjectInspector.GetRegistrySizeAttribute<T>();
        if (regSize != null)
        {
            if (line.Length != regSize.Length)
            {
                throw new InvalidOperationException($"Deserialization cancelled due to Length mismatch. Line-Lenght: {line.Length} Expected: {regSize.Length}");
            }
        }

        return bs.Deserialize<T>(new StringReader(line), out Results);
    }
}
