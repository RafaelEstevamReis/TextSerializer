using System;
using System.Collections.Generic;

namespace TextSerializer
{
    public class SerializationResult
    {
        public List<Exception> Errors { get; private set; } = [];
    }
}
