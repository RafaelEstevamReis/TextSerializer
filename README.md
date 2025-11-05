# TextSerializer

![.NET](https://github.com/RafaelEstevamReis/TextSerializer/actions/workflows/dotnet.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/RafaelEstevam.TextSerializer)](https://www.nuget.org/packages/RafaelEstevam.TextSerializer/)


A zero-dependency small library to serialize and deserialize text-based fixed length files

It reads and generates text files with Fixedlen structure

## How to use?

1. Decorate you model
~~~
public class Example
{
    [Index(1), Type(DataType.N), Length(1)]
    public int DocumentType { get; set; }

    [Index(2), Type(DataType.N), Length(1)]
    public int Operation { get; set; }

    [Index(3), Type(DataType.C), Length(7)]
    public string OperationName { get; set; }
}
~~~

2. Serialize/Deserialize as you would with xml or json
~~~
using var sw = new StreamWriter(...);
LineSerializer.Serialize(example, sw);

OR

using var sw = new StreamWriter(...);
var example = LineSerializer.Deserialize<Example>(sr);
~~~

See more examples at TextSerializer.Test folder
