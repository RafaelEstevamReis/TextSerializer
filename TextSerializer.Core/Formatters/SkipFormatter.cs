﻿using System;

namespace TextSerializer.Formatters
{
    public class SkipFormatter : Formatter
    {
        override public string Serialize(SerializableValue Value)
        {
            throw new InvalidOperationException("Cannot serialize a property marked with SkipAttribute ");
        }
        override public bool Deserialize(string Block, SerializableValue Value)
        {
            return true;
        }
    }
}
