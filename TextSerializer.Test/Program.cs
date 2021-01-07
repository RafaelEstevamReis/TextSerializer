using System;
using System.IO;
using System.Text;

namespace TextSerializer.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var example = new Example()
            {
                DocumentType = 0,
                Operation = 1,
                OperationName = "OPNAME",
                ServiceCode = 2,
                ServiceName = "SERVNAME",
                ActionCode = "3",
                FunctionCode = "7",
                CheckDigit = "4",
                CompanyName = "Example LTD",
                IssuerCode = "123",
                IssuerName = "Issuer LTD",
                CreationDate = DateTime.Now,
                SequencialCode = 1,
            };

            var opt = new SerializationOptions()
            {
                 DateTimeFormat = "ddMMyy"
            };
            LineSerializer line = new LineSerializer(opt);

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(ms);
            line.Serialize(example, sw);

            var text = Encoding.UTF8.GetString(ms.ToArray());
            
            Console.WriteLine(text);


            // Convert back
            var example2 = line.Deserialize<Example>(text.Replace("\r\n", ""), out _);

        }
    }
}