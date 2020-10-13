using System;
using System.Collections.Generic;

namespace TextSerializer
{
    public class SerializationResult
    {
        public SerializationResult()
        {
            Errors = new List<Exception>();
        }

        public List<Exception> Errors { get; private set; }
    }
}
