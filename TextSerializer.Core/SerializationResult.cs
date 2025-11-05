namespace TextSerializer;

using System;
using System.Collections.Generic;

public class SerializationResult
{
    public List<Exception> Errors { get; private set; } = [];
}
