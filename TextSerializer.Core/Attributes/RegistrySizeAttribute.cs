using System;

namespace TextSerializer.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class RegistrySizeAttribute : Attribute
    {
        public int Length { get; }

        public RegistrySizeAttribute(int length)
        {
            Length = length;
        }
    }
}
