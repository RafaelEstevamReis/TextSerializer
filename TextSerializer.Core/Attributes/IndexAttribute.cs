using System;

namespace TextSerializer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class IndexAttribute : Attribute
    {
        public int Index { get; }

        public IndexAttribute(int index)
        {
            Index = index;
        }
    }
}
