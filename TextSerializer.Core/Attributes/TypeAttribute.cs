﻿using System;

namespace TextSerializer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class TypeAttribute : Attribute
    {
        public DataType Type { get; private set; }

        public TypeAttribute(DataType type)
        {
            Type = type;
        }
    }
}
