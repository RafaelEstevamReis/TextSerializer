namespace TextSerializer.Attributes;

using System;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class LengthAttribute : Attribute
{
    public enum CountMode
    {
        /// <summary>
        /// Decimal places are already counted in the Length
        /// </summary>
        DecimalsInclusive,
        /// <summary>
        /// Decimal places are not counted in the Length
        /// Length will be increased to account for it
        /// </summary>
        DecimalsExclusive,
    }

    public int Length { get; }
    public int Decimals { get; }

    public LengthAttribute(int length)
        : this(length, 0)
    { }
    public LengthAttribute(int length, int decimals, CountMode mode = CountMode.DecimalsInclusive)
    {
        Length = length;
        Decimals = decimals;

        if (mode == CountMode.DecimalsExclusive) Length += decimals;
    }
}
