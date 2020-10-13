using System;

namespace TextSerializer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class LengthAttribute : Attribute
    {
        public int Length { get; }
        public int Decimals { get; }

        public LengthAttribute(int length)
            : this(length, 0)
        { }
        public LengthAttribute(int length, int decimals)
        {
            Length = length;
            Decimals = Decimals;
        }
    }
}
