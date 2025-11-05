namespace TextSerializer.Attributes;

using System;

/// <summary>
/// Optional Attribute. Allows class-wide length check
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class RegistrySizeAttribute : Attribute
{
    public int Length { get; }

    public RegistrySizeAttribute(int length)
    {
        Length = length;
    }
}
